namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS.Models.MediaFlexPlatformCommunication
{
	using System.Xml.Serialization;

	using Newtonsoft.Json;

	/// <summary>
	/// 
	/// </summary>
	[XmlRoot("sourceItemSearch")]
	public class SourceItemSearch
	{
		/// <summary>
		/// 
		/// </summary>
		[XmlElement("searchType")]
		[JsonProperty("searchType")]
		public string SearchType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[XmlElement("search")]
		[JsonProperty("search")]
		public Search Search { get; set; }
	}
}
