using System;

namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS
{
	public interface ITmdMediaFlexUmsElement
	{
		string Name { get; }
		TimeSpan Timeout { get; }

		void AddMetadata(Job job);
		void AddMetadata(string plasmaId, DataminerMetadata metadata);
	}
}