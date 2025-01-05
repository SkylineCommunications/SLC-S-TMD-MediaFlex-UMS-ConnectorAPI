namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS
{
	using Newtonsoft.Json;
	using System.Xml.Serialization;
	using System;

	[XmlRoot("task")]
	public class Task
	{
		[XmlElement("itemUrl")]
		[JsonProperty("itemUrl")]
		public string ItemUrl { get; set; }

		[XmlElement("parent")]
		[JsonProperty("parent")]
		public string Parent { get; set; }

		[XmlElement("id")]
		[JsonProperty("id")]
		public int Id { get; set; }

		[XmlElement("taskType")]
		[JsonProperty("taskType")]
		public string TaskType { get; set; }

		[XmlElement("name")]
		[JsonProperty("name")]
		public string Name { get; set; }

		[XmlElement("taskIndex")]
		[JsonProperty("taskIndex")]
		public int TaskIndex { get; set; }

		[XmlElement("notes")]
		[JsonProperty("notes")]
		public string Notes { get; set; }

		[XmlElement("taskNotes")]
		[JsonProperty("taskNotes")]
		public string TaskNotes { get; set; }

		[XmlElement("status")]
		[JsonProperty("status")]
		public string Status { get; set; }

		[XmlElement("statusId")]
		[JsonProperty("statusId")]
		public int StatusId { get; set; }

		[XmlElement("lockedBy")]
		[JsonProperty("lockedBy")]
		public string LockedBy { get; set; }

		[XmlElement("startedDate")]
		[JsonProperty("startedDate")]
		public DateTime StartedDate { get; set; }
	}
}
