namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Xml.Serialization;

	using Newtonsoft.Json;

	/// <summary>
	/// Represents a response for a task or operation request within a Media Asset Management (MAM) system.
	/// Encapsulates metadata and parameters for processing media assets in workflows.
	/// </summary>
	[XmlRoot("job")]
	public class JobResponse
	{
		[XmlElement("itemUrl")]
        [JsonProperty("itemUrl")]
		public string ItemUrl { get; set; }

		[XmlElement("id")]
        [JsonProperty("id")]
		public int Id { get; set; }

		/// <summary>
		/// A unique identifier for the job within the MAM system.
		/// Ensures traceability and facilitates cross-referencing.
		/// </summary>
		[XmlElement("jobRef")]
        [JsonProperty("jobRef")]
		public string JobRef { get; set; }

		/// <summary>
		/// A reference identifier provided by the client for tracking the job.
		/// Links MAM operations to external systems or business references.
		/// </summary>
		[XmlElement("clientJobRef")]
        [JsonProperty("clientJobRef")]
		public string ClientJobRef { get; set; }

		/// <summary>
		/// Identifies the preset or configuration template applied to the job.
		/// Commonly used for specifying a workflow or operation setup in MAM systems.
		/// </summary>
		[XmlElement("presetId")]
        [JsonProperty("presetId")]
		public int PresetId { get; set; }

		/// <summary>
		/// Identifies the preset or configuration template applied to the job.
		/// Commonly used for specifying a workflow or operation setup in MAM systems.
		/// </summary>
		[XmlElement("presetName")]
        [JsonProperty("presetName")]
		public string PresetName { get; set; }

		[XmlElement("client")]
        [JsonProperty("client")]
		public string Client { get; set; }

		[XmlElement("status")]
        [JsonProperty("status")]
		public string Status { get; set; }

		[XmlElement("statusId")]
        [JsonProperty("statusId")]
		public int StatusId { get; set; }

		[XmlElement("lockedBy")]
        [JsonProperty("lockedBy")]
		public string LockedBy { get; set; }

		[XmlElement("createdDate")]
        [JsonProperty("createdDate")]
		public DateTime CreatedDate { get; set; }

		[XmlElement("startedDate")]
        [JsonProperty("startedDate")]
		public DateTime StartedDate { get; set; }

		[XmlElement("notes")]
        [JsonProperty("notes")]
		public string Notes { get; set; }

		[XmlArray("tasks")]
		[XmlArrayItem("task")]
        [JsonProperty("tasks")]
		public List<Task> Tasks { get; set; }

		/// <summary>
		/// Serializes the current job to XML.
		/// </summary>
		/// <returns>XML serialized string representing this instance.</returns>
		public string SerializeToXml()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(JobResponse));
			using (var stringWriter = new StringWriter())
			{
				serializer.Serialize(stringWriter, this);
				return stringWriter.ToString();
			}
		}

		/// <summary>
		/// Serializes the current job to JSON.
		/// </summary>
		/// <returns>JSON serialized string representing this instance.</returns>
		public string SerializeToJson()
		{
			return JsonConvert.SerializeObject(this);
		}

		/// <summary>
		/// Deserializes the provided XML to a JobResponse instance.
		/// </summary>
		/// <param name="serializedJob">XML representing a JobResponse instance.</param>
		/// <returns>Deserialized JobResponse instance.</returns>
		public static JobResponse DeserializeFromXml(string serializedJob)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(JobResponse));
			using (var stringReader = new StringReader(serializedJob))
			{
				return (JobResponse)serializer.Deserialize(stringReader);
			}
		}

		/// <summary>
		/// Deserializes the provided JSON to a JobResponse instance.
		/// </summary>
		/// <param name="serializedJob">JSON representing a JobResponse instance.</param>
		/// <returns>Deserialized JobResponse instance.</returns>
		public static JobResponse DeserializeFromJson(string serializedJob)
		{
			return JsonConvert.DeserializeObject<JobResponse>(serializedJob);
		}
	}
}
