namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS
{
	using System.Xml.Serialization;

	using Newtonsoft.Json;

	/// <summary>
	/// 
	/// </summary>
	[XmlRoot("param")]
	public class Param
	{
		/// <summary>
		/// 
		/// </summary>
		[XmlElement("name")]
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[XmlElement("value")]
		[JsonProperty("value")]
		public string Value { get; set; }
	}
}