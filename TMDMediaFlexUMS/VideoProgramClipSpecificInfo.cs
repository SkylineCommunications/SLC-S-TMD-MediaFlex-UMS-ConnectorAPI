﻿namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// Represents specific details about a video program or clip within a Media Asset Management (MAM) system.
    /// This information is critical for technical validation, categorization, and distribution of media assets.
    /// </summary>
    [XmlRoot("VideoProgramClipSpecificInfo")]
    public class VideoProgramClipSpecificInfo
    {
        /// <summary>
        /// The type of video (e.g., program, clip, advertisement) for classification and processing purposes.
        /// </summary>
        [XmlElement("VideoType")]
        [JsonProperty("VideoType")]
        public string VideoType { get; set; }

        /// <summary>
        /// A textual description of the video, providing additional context or summary for cataloging.
        /// </summary>
        [XmlElement("Description")]
        [JsonProperty("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Unique identifier for the video in the Plasma database or system.
        /// </summary>
        [XmlElement("PlasmaID")]
        [JsonProperty("PlasmaID")]
        public string PlasmaID { get; set; }

        /// <summary>
        /// Unique identifier for the video in the Yle database or system.
        /// </summary>
        [XmlElement("YleID")]
        [JsonProperty("YleID")]
        public string YleID { get; set; }

        /// <summary>
        /// The MD5 hash of the video file, used for integrity verification.
        /// </summary>
        [XmlElement("MD5")]
        [JsonProperty("MD5")]
        public string MD5 { get; set; }

        /// <summary>
        /// Timecode indicating the start of the video file, useful for editing and playback synchronization.
        /// </summary>
        [XmlElement("StartOfFile")]
        [JsonProperty("StartOfFile")]
        public string StartOfFile { get; set; }

        /// <summary>
        /// Timecode indicating the end of the video file, essential for determining the duration.
        /// </summary>
        [XmlElement("EndOfFile")]
        [JsonProperty("EndOfFile")]
        public string EndOfFile { get; set; }

        /// <summary>
        /// Timecode marking the start of the actual media content (excluding black or slate frames).
        /// </summary>
        [XmlElement("StartOfMedia")]
        [JsonProperty("StartOfMedia")]
        public string StartOfMedia { get; set; }

        /// <summary>
        /// Timecode marking the end of the actual media content.
        /// </summary>
        [XmlElement("EndOfMedia")]
        [JsonProperty("EndOfMedia")]
        public string EndOfMedia { get; set; }

        /// <summary>
        /// Specifies the type of timecode used (e.g., drop-frame, non-drop-frame).
        /// </summary>
        [XmlElement("timeCodeType")]
        [JsonProperty("timeCodeType")]
        public string TimeCodeType { get; set; }

        /// <summary>
        /// The resolution of the video (e.g., 1920x1080), crucial for quality assurance and distribution requirements.
        /// </summary>
        [XmlElement("resolution")]
        [JsonProperty("resolution")]
        public string Resolution { get; set; }

        /// <summary>
        /// The codec used for encoding the video, determining its compression and compatibility.
        /// </summary>
        [XmlElement("codec")]
        [JsonProperty("codec")]
        public string Codec { get; set; }

        /// <summary>
        /// The bitrate of the video, typically measured in kbps, indicating its quality and size.
        /// </summary>
        [XmlElement("bitrate")]
        [JsonProperty("bitrate")]
        public string Bitrate { get; set; }

        /// <summary>
        /// Additional picture information (e.g., chroma subsampling) for technical validation.
        /// </summary>
        [XmlElement("pi")]
        [JsonProperty("pi")]
        public string Pi { get; set; }

        /// <summary>
        /// The aspect ratio of the video (e.g., 16:9), important for display compatibility.
        /// </summary>
        [XmlElement("aspectRatio")]
        [JsonProperty("aspectratio")]
        public string AspectRatio { get; set; }

        /// <summary>
        /// The frame rate of the video, indicating the number of frames displayed per second.
        /// </summary>
        [XmlElement("frameRate")]
        [JsonProperty("framerate")]
        public int FrameRate { get; set; }

        /// <summary>
        /// Indicates whether the video is ready for transmission (e.g., broadcast or streaming).
        /// </summary>
        [XmlElement("TransmissionReady")]
        [JsonProperty("TransmissionReady")]
        public bool TransmissionReady { get; set; }

        /// <summary>
        /// Contains detailed information about the audio assets associated with the video.
        /// </summary>
        [XmlArray("AudioAssetInfo")]
        [XmlArrayItem("AudioAsset")]
        [JsonProperty("AudioAssetInfo")]
        public List<AudioAsset> AudioAssetInfo { get; set; }

        /// <summary>
        /// The bitrate of the audio track, affecting its quality and size.
        /// </summary>
        [XmlElement("audioBitRate")]
        [JsonProperty("audioBitRate")]
        public string AudioBitRate { get; set; }

        /// <summary>
        /// The codec used for encoding the audio track, determining its format and compatibility.
        /// </summary>
        [XmlElement("audioCodec")]
        [JsonProperty("audioCodec")]
        public string AudioCodec { get; set; }

        /// <summary>
        /// Any additional information or metadata about the video program or clip.
        /// </summary>
        [XmlElement("additionalinfo")]
        [JsonProperty("additionalInfo")]
        public string AdditionalInfo { get; set; }
    }

}
