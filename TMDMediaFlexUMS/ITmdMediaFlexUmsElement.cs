namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS
{
	using System;
	using Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS.Models.Element;
	using Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS.Models.MediaFlexPlatformCommunication;
	
	/// <summary>
	/// Defines an interface to interact with an element running the TMD MediaFlex UMS protocol.
	/// </summary>
	public interface ITmdMediaFlexUmsElement
	{
		/// <summary>
		/// Gets the name of the element.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Gets the time-out for interapp communication defined in the element.
		/// </summary>
		TimeSpan InterAppTimeout { get; }

		/// <summary>
		/// Gets the file status update for the gived ID.
		/// </summary>
		/// <param name="fileStatusUpdateId"></param>
		/// <returns></returns>
		FileStatusUpdate GetFileStatusUpdate(string fileStatusUpdateId);

		/// <summary>
		/// Sends a file status update to the element.
		/// </summary>
		/// <param name="fileStatusUpdate"></param>
		void SendFileStatusUpdate(FileStatusUpdate fileStatusUpdate);

		/// <summary>
		/// Adds metadata to the MediaFlex platform.
		/// </summary>
		/// <param name="job"></param>
		void AddMetadata(Job job);

		/// <summary>
		/// Adds metadata to the MediaFlex platform.
		/// </summary>
		/// <param name="plasmaId"></param>
		/// <param name="metadata"></param>
		void AddMetadata(string plasmaId, DataminerMetadata metadata);
	}
}