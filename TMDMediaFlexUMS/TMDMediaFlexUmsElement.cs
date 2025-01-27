namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;

	using Newtonsoft.Json;
	using Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS.Messages;
	using Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS.Models.Element;
	using Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS.Models.MediaFlexPlatformCommunication;
	using Skyline.DataMiner.Core.DataMinerSystem.Common;
	using Skyline.DataMiner.Core.InterAppCalls.Common.CallBulk;
	using Skyline.DataMiner.Core.InterAppCalls.Common.CallSingle;
	using Skyline.DataMiner.Net;

	/// <summary>
	/// Represents a TMD MediaFlex UMS element in DataMiner and exposes methods to request and release locks on specific objects.
	/// </summary>
	public class TmdMediaFlexUmsElement : ITmdMediaFlexUmsElement
	{
		private readonly IConnection connection;
		private readonly IDmsElement element;
		private readonly ILogger logger;

		private TimeSpan? timeout;

		private static readonly List<System.Type> knownTypes = new List<System.Type>
		{
			typeof(IInterAppCall),
			typeof(AddWorkflowMetadataRequest),
			typeof(AddWorkflowMetadataResponse),
			typeof(AudioAsset),
			typeof(FinalCheck),
			typeof(GeneralInformation),
			typeof(DataminerMetadata),
			typeof(VideoProgramClipSpecificInfo),
		};

		/// <summary>
		/// List of known types. Used during InterApp communication.
		/// </summary>
		public static IEnumerable<System.Type> KnownTypes => knownTypes;

		/// <summary>
		/// Gets the name of the DataMiner element.
		/// </summary>
		public string Name => element.Name;

		/// <summary>
		/// Initializes a new instance of the <see cref="TmdMediaFlexUmsElement"/> class.
		/// </summary>
		/// <param name="connection">Connection used to communicate with the MediaFlex UMS element.</param>
		/// <param name="agentId">ID of the agent on which the MediaFlex UMS element is hosted.</param>
		/// <param name="elementId">ID of the MediaFlex UMS element.</param>
		/// <param name="logger">Used to log debug info from the <see cref="TmdMediaFlexUmsElement"/> instance.</param>
		/// <exception cref="ArgumentNullException">Thrown when the provided connection or the element is null.</exception>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when provided element id or agent id is negative.</exception>
		/// <exception cref="InvalidOperationException">Thrown when described element is inactive.</exception>
		public TmdMediaFlexUmsElement(IConnection connection, int agentId, int elementId, ILogger logger = null)
		{
			this.connection = connection ?? throw new ArgumentNullException(nameof(connection));
			if (agentId < 0) throw new ArgumentOutOfRangeException(nameof(agentId), "Agent ID cannot be negative");
			if (elementId < 0) throw new ArgumentOutOfRangeException(nameof(elementId), "Element ID cannot be negative");
			this.logger = logger;

			var dms = connection.GetDms();
			element = dms.GetElement(new DmsElementId(agentId, elementId));

			if (element.State != ElementState.Active) throw new InvalidOperationException($"Element {element.Name} is not active");
		}

		/// <summary>
		/// Maximum amount of time in which every request to the MediaFlex UMS element should be handled.
		/// Default: 10 seconds.
		/// </summary>
		public TimeSpan InterAppTimeout
		{
			get
			{
				if (timeout != null) return (TimeSpan)timeout;
				try
				{
					var timeoutInSeconds = element.GetStandaloneParameter<double?>(TmdMediaFlexUmsProtocol.InterAppTimeoutPid);
					timeout = TimeSpan.FromSeconds(timeoutInSeconds.GetValue().Value);
					return (TimeSpan)timeout;
				}
				catch (Exception e)
				{
					Log($"Unable to retrieve timeout from element due to {e}, defaulting to 10 seconds.");
					timeout = TimeSpan.FromSeconds(10);
					return (TimeSpan)timeout;
				}
			}
		}

		/// <summary>
		/// Provides metadata about a recording to MediaFlex. Prefills job fields with default values.
		/// </summary>
		/// <param name="plasmaId">Plasma ID of the recording.</param>
		/// <param name="metadata">Metadata of the recording.</param>
		/// <exception cref="InvalidOperationException">Thrown in case the InterApp communication fails or if the request to MediaFlex fails.</exception>
		public void AddMetadata(string plasmaId, DataminerMetadata metadata)
		{
			var job = new Job();
			job.SourceItems.Add(
				new SourceItemSearch
				{
					SearchType = "version",
					Search = new Search
					{
						Parameters = new List<Param>
						{
							new Param
							{
								Name = "versionid1",
								Value = plasmaId,
							},
							new Param
							{
								Name = "versionName",
								Value = "Program Video"
							}
						}
					}
				}
			);
			job.CustomMetadataDocs.Add(new CustomMetadataDoc { SchemaId = "1235", DocumentBody = new DocumentBody { DataminerMetadata = metadata } });

			AddMetadata(job);
		}

		/// <summary>
		/// Provides metadata about a recording to MediaFlex. This call allows the user to fully define the Job isntance sent to MediaFlex.
		/// </summary>
		/// <param name="job">Job responsible for delivering recording metadata.</param>
		/// <exception cref="InvalidOperationException">Thrown in case the InterApp communication fails or if the request to MediaFlex fails.</exception>
		public void AddMetadata(Job job)
		{
			var request = new AddWorkflowMetadataRequest
			{
				Job = job
			};

			if (!TrySendMessage(request, true, out string reason, out AddWorkflowMetadataResponse response))
			{
				Log($"Something when wrong in InterApp communication: {reason}");
				throw new InvalidOperationException($"Unable to add meta data to recording due to {reason}");
			}

			if (!response.Success)
			{
				Log($"Failed response received: {reason}");
				throw new InvalidOperationException($"Unable to add meta data to recording due to {response.Reason}");
			}
		}

		/// <summary>
		/// Gets the <see cref="FileStatusUpdate"/> for the gived ID.
		/// </summary>
		/// <param name="fileStatusUpdateId"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="InvalidOperationException"></exception>
		public FileStatusUpdate GetFileStatusUpdate(string fileStatusUpdateId)
		{
			if (string.IsNullOrWhiteSpace(fileStatusUpdateId))
			{
				throw new ArgumentException($"'{nameof(fileStatusUpdateId)}' cannot be null or whitespace.", nameof(fileStatusUpdateId));
			}

			var fileStatusUpdatesRow = element.GetTable(TmdMediaFlexUmsProtocol.FileStatusUpdatesTable.TablePid).GetRow(fileStatusUpdateId) ?? throw new InvalidOperationException($"No row found with primary key '{fileStatusUpdateId}'");
			
			var fileStatusUpdate = new FileStatusUpdate
			{
				Id = Convert.ToString(fileStatusUpdatesRow[TmdMediaFlexUmsProtocol.FileStatusUpdatesTable.Idx.Id]),
				PlasmaId = Convert.ToString(fileStatusUpdatesRow[TmdMediaFlexUmsProtocol.FileStatusUpdatesTable.Idx.PlasmaId]),
				TimeStamp = DateTime.FromOADate(Convert.ToDouble(fileStatusUpdatesRow[TmdMediaFlexUmsProtocol.FileStatusUpdatesTable.Idx.Timestamp])),
				Type = (Models.Element.Type)Convert.ToInt32(fileStatusUpdatesRow[TmdMediaFlexUmsProtocol.FileStatusUpdatesTable.Idx.Type]),
				Status = (Status)Convert.ToInt32(fileStatusUpdatesRow[TmdMediaFlexUmsProtocol.FileStatusUpdatesTable.Idx.Status]),
				Description = Convert.ToString(fileStatusUpdatesRow[TmdMediaFlexUmsProtocol.FileStatusUpdatesTable.Idx.Description]),
			};

			return fileStatusUpdate;
		}

		/// <summary>
		/// Sends a file status update message to the web service of the element.
		/// </summary>
		/// <param name="fileStatusUpdate"></param>
		/// <exception cref="ArgumentNullException"></exception>
		public void SendFileStatusUpdate(FileStatusUpdate fileStatusUpdate)
		{
			if (fileStatusUpdate is null)
			{
				throw new ArgumentNullException(nameof(fileStatusUpdate));
			}

			string serializedFileStatusUpdate = JsonConvert.SerializeObject(fileStatusUpdate);

			element.GetStandaloneParameter<string>(TmdMediaFlexUmsProtocol.LastNotificationPid).SetValue(serializedFileStatusUpdate);

			Log($"Sent File Status Update '{serializedFileStatusUpdate}'");
		}

		private bool TrySendMessage<T>(Message message, bool requiresResponse, out string reason, out T responseMessage) where T : Message
		{
			reason = String.Empty;
			responseMessage = default(T);

			var commands = InterAppCallFactory.CreateNew();
			commands.Messages.Add(message);

			Log($"Message: {JsonConvert.SerializeObject(message)}");

			try
			{
				if (requiresResponse)
				{
					var response = commands.Send(connection, element.AgentId, element.Id, TmdMediaFlexUmsProtocol.InterAppReceivePid, InterAppTimeout, knownTypes).First();
					if (!(response is T castResponse))
					{
						reason = $"Received response is not of type {typeof(T)}";
						return false;
					}

					responseMessage = castResponse;
				}
				else
				{
					commands.Send(connection, element.AgentId, element.Id, TmdMediaFlexUmsProtocol.InterAppReceivePid, knownTypes);
				}
			}
			catch (Exception e)
			{
				reason = e.ToString();
				return false;
			}

			return true;
		}

		private void Log(string message)
		{
			if (logger == null)
			{
				return;
			}

			string nameOfMethod = new StackTrace().GetFrame(1).GetMethod().Name;

			logger.Log(GetType().Name, nameOfMethod, message);
		}
	}
}
