namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS;
    using System;

    [TestClass]
    public class JobTests
    {
        private const string SerializedJob = "<job>\r\n\t<presetName>DataminerMTDInWflow</presetName>\r\n\t<notes>Test Dataminer version job w Doc</notes>\r\n\t<clientJobRef/>\r\n\t<client>YLE</client>\r\n\t<jobRef/>\r\n\t<priority>High</priority>\r\n\t<customMetadataDocs>\r\n\t\t<customMetadataDoc>\r\n\t\t\t<schemaId>1235</schemaId>\r\n\t\t\t<documentBody>\r\n\t\t\t\t<DataminerMetadata>\r\n\t\t\t\t\t<GeneralInformation>\r\n\t\t\t\t\t\t<LiveOrderName>test1</LiveOrderName>\r\n\t\t\t\t\t\t<timestamp>2021-12-01T13:53:26</timestamp>\r\n\t\t\t\t\t\t<sourceSystem>test2</sourceSystem>\r\n\t\t\t\t\t\t<SubtitleProxyNeeded>true</SubtitleProxyNeeded>\r\n\t\t\t\t\t\t<FastRerun>false</FastRerun>\r\n\t\t\t\t\t\t<AreenaCopyNeeded>true</AreenaCopyNeeded>\r\n\t\t\t\t\t\t<DeadlineForArchiving>2021-12-15T13:53:52</DeadlineForArchiving>\r\n\t\t\t\t\t</GeneralInformation>\r\n\t\t\t\t\t<FinalCheck>\r\n\t\t\t\t\t\t<MAMImportComments>tes3</MAMImportComments>\r\n\t\t\t\t\t\t<MediaOperatorName>test4</MediaOperatorName>\r\n\t\t\t\t\t</FinalCheck>\r\n\t\t\t\t\t<VideoProgramClipSpecificInfo>\r\n\t\t\t\t\t\t<VideoType>test5</VideoType>\r\n\t\t\t\t\t\t<Description>test6</Description>\r\n\t\t\t\t\t\t<PlasmaID>test7</PlasmaID>\r\n\t\t\t\t\t\t<YleID>test8</YleID>\r\n\t\t\t\t\t\t<MD5>test9</MD5>\r\n\t\t\t\t\t\t<StartOfFile>01:01:01:01</StartOfFile>\r\n\t\t\t\t\t\t<EndOfFile>01:01:01:01</EndOfFile>\r\n\t\t\t\t\t\t<StartOfMedia>01:01:01:01</StartOfMedia>\r\n\t\t\t\t\t\t<EndOfMedia>01:01:01:01</EndOfMedia>\r\n\t\t\t\t\t\t<timeCodeType>test10</timeCodeType>\r\n\t\t\t\t\t\t<resolution>test11</resolution>\r\n\t\t\t\t\t\t<codec>test12</codec>\r\n\t\t\t\t\t\t<bitrate>test13</bitrate>\r\n\t\t\t\t\t\t<pi>test14</pi>\r\n\t\t\t\t\t\t<aspectRatio>test15</aspectRatio>\r\n\t\t\t\t\t\t<frameRate>99</frameRate>\r\n\t\t\t\t\t\t<TransmissionReady>true</TransmissionReady>\r\n\t\t\t\t\t\t<AudioAssetInfo>\r\n\t\t\t\t\t\t\t<AudioAsset>\r\n\t\t\t\t\t\t\t\t<trackNumber>2</trackNumber>\r\n\t\t\t\t\t\t\t\t<mixType>test16</mixType>\r\n\t\t\t\t\t\t\t\t<Language>test17</Language>\r\n\t\t\t\t\t\t\t\t<audioType>stereo</audioType>\r\n\t\t\t\t\t\t\t</AudioAsset>\r\n\t\t\t\t\t\t</AudioAssetInfo>\r\n\t\t\t\t\t\t<audioBitRate>test18</audioBitRate>\r\n\t\t\t\t\t\t<audioCodec>test19</audioCodec>\r\n\t\t\t\t\t\t<additionalinfo>test20</additionalinfo>\r\n\t\t\t\t\t</VideoProgramClipSpecificInfo>\r\n\t\t\t\t</DataminerMetadata>\r\n\t\t\t</documentBody>\r\n\t\t</customMetadataDoc>\r\n\t</customMetadataDocs>\r\n\t<versionSourceType>asVersion</versionSourceType>\r\n\t<sourceItems>\r\n\t\t<sourceItem>version/versionid1:FEENIX_P0272885</sourceItem>\r\n\t</sourceItems>\r\n</job>\r\n";

        [TestMethod]
        public void DeserializeJobFromXml()
        {
            var job = Job.DeserializeFromXml(SerializedJob);

            Assert.AreEqual("DataminerMTDInWflow", job.PresetName);
            Assert.AreEqual("Test Dataminer version job w Doc", job.Notes);
            Assert.AreEqual(String.Empty, job.ClientJobRef);
            Assert.AreEqual("YLE", job.Client);
            Assert.AreEqual(String.Empty, job.JobRef);
            Assert.AreEqual("High", job.Priority);
            Assert.AreEqual(1, job.CustomMetadataDocs.Count);
            Assert.AreEqual(1, job.SourceItems.Count);
        }

        [TestMethod]
        public void DeserializeJobFromJson()
        {
            var job = Job.DeserializeFromXml(SerializedJob);

            var serializedJson = job.SerializeToJson();
            job = Job.DeserializeFromJson(serializedJson);

            Assert.AreEqual("DataminerMTDInWflow", job.PresetName);
            Assert.AreEqual("Test Dataminer version job w Doc", job.Notes);
            Assert.AreEqual(String.Empty, job.ClientJobRef);
            Assert.AreEqual("YLE", job.Client);
            Assert.AreEqual(String.Empty, job.JobRef);
            Assert.AreEqual("High", job.Priority);
            Assert.AreEqual(1, job.CustomMetadataDocs.Count);
            Assert.AreEqual(1, job.SourceItems.Count);
        }

        [TestMethod]
        public void SerializeTest()
        {
            var job = Job.DeserializeFromXml(SerializedJob);
            string serializedJob = job.SerializeToXml();

            Assert.IsNotNull(serializedJob);
        }
    }
}