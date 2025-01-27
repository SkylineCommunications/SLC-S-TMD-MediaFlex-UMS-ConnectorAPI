namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS.Models.Element
{
	using System;
	using Newtonsoft.Json;
	using Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS.Helpers;

    /// <summary>
    /// Represent a file status update in MediaFlex.
    /// </summary>
	public class FileStatusUpdate
	{
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the Plasma ID.
        /// </summary>
        [JsonProperty("plasmaId")]
        public string PlasmaId { get; set; }

        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTime TimeStamp { get; set; }

        [JsonProperty("type")]
        internal string ParsedType { get; set; }

        [JsonProperty("status")]
        internal string ParsedStatus { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [JsonIgnore]
        public Type Type
        {
            get
            {
                if (EnumExtensions.TryGetEnumValueFromDescription(ParsedType, out Type type, Ignore.Underscores | Ignore.WhiteSpaces | Ignore.Casing))
                {
                    return type;
                }
                else
                {
                    return Type.Unknown;
                }
            }
            set => ParsedType = EnumExtensions.GetDescription(value);          
        }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        [JsonIgnore]
        public Status Status
        {
            get
            {
                if (EnumExtensions.TryGetEnumValueFromDescription(ParsedStatus, out Status status, Ignore.Underscores | Ignore.WhiteSpaces | Ignore.Casing))
                {
                    return status;
                }
                else
                {
                    return Status.Unknown;
                }
            }
            set => ParsedStatus = EnumExtensions.GetDescription(value);           
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        
        /// <summary>
        /// Gets the hash code of this object?
        /// </summary>
        /// <returns></returns>
		public override int GetHashCode()
		{
			int hashCode = (Id == null) ? 1 : Id.GetHashCode();

			hashCode = (PlasmaId == null) ? 1 : PlasmaId.GetHashCode();
			hashCode ^= TimeStamp.GetHashCode();
			hashCode ^= (ParsedType == null) ? 1 : ParsedType.GetHashCode();
			hashCode ^= (ParsedStatus == null) ? 1 : ParsedStatus.GetHashCode();
			hashCode ^= (Description == null) ? 1 : Description.GetHashCode();

			return hashCode;
		}

        /// <summary>
        /// Gets the equality compared to a second object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
		public override bool Equals(object obj)
		{
			return obj is FileStatusUpdate update &&
				   Id == update.Id &&
				   PlasmaId == update.PlasmaId &&
				   TimeStamp == update.TimeStamp &&
				   ParsedType == update.ParsedType &&
				   ParsedStatus == update.ParsedStatus &&
				   Type == update.Type &&
				   Status == update.Status &&
				   Description == update.Description;
		}
	}
}
