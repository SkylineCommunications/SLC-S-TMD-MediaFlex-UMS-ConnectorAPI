using Newtonsoft.Json;
using Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS.Messages;
using Skyline.DataMiner.Core.DataMinerSystem.Common;
using Skyline.DataMiner.Core.InterAppCalls.Common.CallBulk;
using Skyline.DataMiner.Core.InterAppCalls.Common.CallSingle;
using Skyline.DataMiner.Net;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS
{
    /// <summary>
    /// Represents a TMD MediaFlex UMS element in DataMiner and exposes methods to request and release locks on specific objects.
    /// </summary>
    public class MediaFlexUmsElement
    {
        private readonly IConnection connection;
        private readonly IDmsElement element;

        private TimeSpan? timeout;

        private static readonly List<Type> knownTypes = new List<Type>
        {
            typeof(IInterAppCall),
            typeof(AddWorkflowMetadataRequest),
            typeof(AddWorkflowMetadataResponse),
            typeof(AudioAsset),
            typeof(AudioAssetInfo),
            typeof(FinalCheck),
            typeof(GeneralInformation),
            typeof(Metadata),
            typeof(VideoProgramClipSpecificInfo),
        };

        /// <summary>
        /// List of known types. Used during InterApp communication.
        /// </summary>
        public static IEnumerable<Type> KnownTypes => knownTypes;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaFlexUmsElement"/> class.
        /// </summary>
        /// <param name="connection">Connection used to communicate with the MediaFlex UMS element.</param>
        /// <param name="agentId">ID of the agent on which the MediaFlex UMS element is hosted.</param>
        /// <param name="elementId">ID of the MediaFlex UMS element.</param>
        /// <exception cref="ArgumentNullException">Thrown when the provided connection or the element is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when provided element id or agent id is negative.</exception>
        /// <exception cref="InvalidOperationException">Thrown when described element is inactive.</exception>
        public MediaFlexUmsElement(Connection connection, int agentId, int elementId)
        {
            this.connection = connection ?? throw new ArgumentNullException(nameof(connection));
            if (agentId < 0) throw new ArgumentOutOfRangeException(nameof(agentId), "Agent ID cannot be negative");
            if (elementId < 0) throw new ArgumentOutOfRangeException(nameof(elementId), "Element ID cannot be negative");

            var dms = connection.GetDms();
            element = dms.GetElement(new DmsElementId(agentId, elementId));

            if (element.State != ElementState.Active) throw new InvalidOperationException($"Element {element.Name} is not active");
        }

        /// <summary>
        /// Maximum amount of time in which every request to the MediaFlex UMS element should be handled.
        /// Default: 10 seconds.
        /// </summary>
        public TimeSpan Timeout
        {
            get
            {
                if (timeout != null) return (TimeSpan)timeout;
                try
                {
                    var timeoutInSeconds = element.GetStandaloneParameter<double?>(TMDMediaFlexUMSProtocol.InterAppTimeoutPid) ?? throw new NullReferenceException("InterApp Timeout value is null.");
                    timeout = TimeSpan.FromSeconds(timeoutInSeconds.GetValue().Value);
                    return (TimeSpan)timeout;
                }
                catch (Exception)
                {
                    timeout = TimeSpan.FromSeconds(10);
                    return (TimeSpan)timeout;
                }
            }
        }

        /// <summary>
        /// Provides metadata about a recording to MediaFlex.
        /// </summary>
        /// <param name="plasmaId">Plasma ID of the recording.</param>
        /// <param name="metadata">Metadata of the recording.</param>
        /// <exception cref="InvalidOperationException">Thrown in case the InterApp communication fails or if the request to MediaFlex fails.</exception>
        public void AddMetadata(string plasmaId, Metadata metadata)
        {
            var request = new AddWorkflowMetadataRequest
            {
                PlasmaId = plasmaId,
                Metadata = metadata,
            };

            if (!TrySendMessage(request, true, out string reason, out AddWorkflowMetadataResponse response))
            {
                throw new InvalidOperationException($"Unable to add meta data to recording with Plasma ID {plasmaId} due to {reason}");
            }

            if (!response.Success)
            {
                throw new InvalidOperationException($"Unable to add meta data to recording with Plasma ID {plasmaId} due to {response.Reason}");
            }
        }

        private bool TrySendMessage<T>(Message message, bool requiresResponse, out string reason, out T responseMessage) where T : Message
        {
            reason = String.Empty;
            responseMessage = default(T);

            var commands = InterAppCallFactory.CreateNew();
            commands.Messages.Add(message);

            try
            {
                if (requiresResponse)
                {
                    var response = commands.Send(connection, element.AgentId, element.Id, TMDMediaFlexUMSProtocol.InterAppReceivePid, Timeout, knownTypes).First();
                    if (!(response is T castResponse))
                    {
                        reason = $"Received response is not of type {typeof(T)}";
                        return false;
                    }

                    responseMessage = castResponse;
                }
                else
                {
                    commands.Send(connection, element.AgentId, element.Id, TMDMediaFlexUMSProtocol.InterAppReceivePid, knownTypes);
                }
            }
            catch (Exception e)
            {
                reason = e.ToString();
                return false;
            }

            return true;
        }
    }
}
