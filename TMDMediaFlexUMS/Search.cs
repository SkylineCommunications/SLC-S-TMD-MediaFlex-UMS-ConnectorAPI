namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS
{
	using System.Collections.Generic;
	using System.Xml.Serialization;

	using Newtonsoft.Json;

	/// <summary>
	/// 
	/// </summary>
	[XmlRoot("search")]
	public class Search
	{
		/// <summary>
		/// 
		/// </summary>
		[XmlElement("parameters")]
		[XmlArrayItem("param")]
		[JsonProperty("parameters")]
		public List<Param> Parameters { get; set; }
	}
}
