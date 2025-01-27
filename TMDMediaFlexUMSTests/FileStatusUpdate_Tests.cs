namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS.Tests
{
	using System;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Newtonsoft.Json;
	using Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS.Models.Element;

	[TestClass()]
	public class FileStatusUpdate_Tests
	{
		[TestMethod()]
		public void Deserialize_Notification_ProgramWorkflowStarted()
		{
			string serializedNotification = "{\"id\":\"PLASMA_P1234567\",\"timestamp\":\"2022-05-18T16:19:24+0300\",\"type\":\"PROGRAM_VIDEO\",\"status\":\"WORKFLOW_STARTED\",\"description\":\"\"}";

			var notification = JsonConvert.DeserializeObject<FileStatusUpdate>(serializedNotification);

			Assert.IsNotNull(notification);
			Assert.AreEqual("PLASMA_P1234567", notification.Id);
			Assert.AreEqual(Models.Element.Type.ProgramVideo, notification.Type);
			Assert.AreEqual(Status.WorkflowStarted, notification.Status);
			Assert.AreEqual(String.Empty, notification.Description);
		}

		[TestMethod()]
		public void Deserialize_Notification_ProgramDeliverySuccessful()
		{
			string serializedNotification = "{\"id\":\"PLASMA_P1234567\",\"timestamp\":\"2022-05-18T16:19:24+0300\",\"type\":\"PROGRAM_VIDEO\",\"status\":\"DELIVERY_SUCCESSFUL\",\"description\":\"\"}";

			var notification = JsonConvert.DeserializeObject<FileStatusUpdate>(serializedNotification);

			Assert.IsNotNull(notification);
			Assert.AreEqual("PLASMA_P1234567", notification.Id);
			Assert.AreEqual(Models.Element.Type.ProgramVideo, notification.Type);
			Assert.AreEqual(Status.DeliverySuccessful, notification.Status);
			Assert.AreEqual(String.Empty, notification.Description);
		}

		[TestMethod()]
		public void Deserialize_Notification_ProgramDeliveryFailed()
		{
			string serializedNotification = "{\"id\":\"PLASMA_P1234567\",\"timestamp\":\"2022-05-18T16:19:24+0300\",\"type\":\"PROGRAM_VIDEO\",\"status\":\"DELIVERY_FAILED\",\"description\":\"Something went terribly wrong\"}";

			var notification = JsonConvert.DeserializeObject<FileStatusUpdate>(serializedNotification);

			Assert.IsNotNull(notification);
			Assert.AreEqual("PLASMA_P1234567", notification.Id);
			Assert.AreEqual(Models.Element.Type.ProgramVideo, notification.Type);
			Assert.AreEqual(Status.DeliveryFailed, notification.Status);
			Assert.AreEqual("Something went terribly wrong", notification.Description);
		}

		[TestMethod()]
		public void Deserialize_Notification_ProgramQcPassed()
		{
			string serializedNotification = "{\"id\":\"PLASMA_P1234567\",\"timestamp\":\"2022-05-18T16:19:24+0300\",\"type\":\"PROGRAM_VIDEO\",\"status\":\"QC_PASSED\",\"description\":\"Something went terribly wrong\"}";

			var notification = JsonConvert.DeserializeObject<FileStatusUpdate>(serializedNotification);

			Assert.IsNotNull(notification);
			Assert.AreEqual("PLASMA_P1234567", notification.Id);
			Assert.AreEqual(Models.Element.Type.ProgramVideo, notification.Type);
			Assert.AreEqual(Status.QcPassed, notification.Status);
			Assert.AreEqual("Something went terribly wrong", notification.Description);
		}

		[TestMethod()]
		public void Deserialize_Notification_ProgramQcFailed()
		{
			string serializedNotification = "{\"id\":\"PLASMA_P1234567\",\"timestamp\":\"2022-05-18T16:19:24+0300\",\"type\":\"PROGRAM_VIDEO\",\"status\":\"QC_FAILED\",\"description\":\"Something went terribly wrong\"}";

			var notification = JsonConvert.DeserializeObject<FileStatusUpdate>(serializedNotification);

			Assert.IsNotNull(notification);
			Assert.AreEqual("PLASMA_P1234567", notification.Id);
			Assert.AreEqual(Models.Element.Type.ProgramVideo, notification.Type);
			Assert.AreEqual(Status.QcFailed, notification.Status);
			Assert.AreEqual("Something went terribly wrong", notification.Description);
		}

		[TestMethod()]
		public void Deserialize_Notification_SubtitleProxyDeliverySuccessful()
		{
			string serializedNotification = "{\"id\":\"PLASMA_P1234567\",\"timestamp\":\"2022-05-18T16:19:24+0300\",\"type\":\"SUBTITLE_PROXIES\",\"status\":\"DELIVERY_SUCCESSFUL\",\"description\":\"Something went terribly wrong\"}";

			var notification = JsonConvert.DeserializeObject<FileStatusUpdate>(serializedNotification);

			Assert.IsNotNull(notification);
			Assert.AreEqual("PLASMA_P1234567", notification.Id);
			Assert.AreEqual(Models.Element.Type.SubtitleProxy, notification.Type);
			Assert.AreEqual(Status.DeliverySuccessful, notification.Status);
			Assert.AreEqual("Something went terribly wrong", notification.Description);
		}

		[TestMethod()]
		public void Deserialize_Notification_SubtitleProxyDeliveryFailed()
		{
			string serializedNotification = "{\"id\":\"PLASMA_P1234567\",\"timestamp\":\"2022-05-18T16:19:24+0300\",\"type\":\"SUBTITLE_PROXIES\",\"status\":\"DELIVERY_FAILED\",\"description\":\"Something went terribly wrong\"}";

			var notification = JsonConvert.DeserializeObject<FileStatusUpdate>(serializedNotification);

			Assert.IsNotNull(notification);
			Assert.AreEqual("PLASMA_P1234567", notification.Id);
			Assert.AreEqual(Models.Element.Type.SubtitleProxy, notification.Type);
			Assert.AreEqual(Status.DeliveryFailed, notification.Status);
			Assert.AreEqual("Something went terribly wrong", notification.Description);
		}

		[TestMethod()]
		public void Deserialize_Notification_ProgramDeliveryUnknownStatus()
		{
			string serializedNotification = "{\"id\":\"PLASMA_P1234567\",\"timestamp\":\"2022-05-18T16:19:24+0300\",\"type\":\"PROGRAM_VIDEO\",\"status\":\"Some random status here\",\"description\":\"Something went terribly wrong\"}";

			var notification = JsonConvert.DeserializeObject<FileStatusUpdate>(serializedNotification);

			Assert.IsNotNull(notification);
			Assert.AreEqual("PLASMA_P1234567", notification.Id);
			Assert.AreEqual(Models.Element.Type.ProgramVideo, notification.Type);
			Assert.AreEqual(Status.Unknown, notification.Status);
			Assert.AreEqual("Something went terribly wrong", notification.Description);
		}

		[TestMethod()]
		public void Deserialize_Notification_UnknownType()
		{
			string serializedNotification = "{\"id\":\"PLASMA_P1234567\",\"timestamp\":\"2022-05-18T16:19:24+0300\",\"type\":\"some very random type here\",\"status\":\"Some random status here\",\"description\":\"Something went terribly wrong\"}";

			var notification = JsonConvert.DeserializeObject<FileStatusUpdate>(serializedNotification);

			Assert.IsNotNull(notification);
			Assert.AreEqual("PLASMA_P1234567", notification.Id);
			Assert.AreEqual(Models.Element.Type.Unknown, notification.Type);
			Assert.AreEqual(Status.Unknown, notification.Status);
			Assert.AreEqual("Something went terribly wrong", notification.Description);
		}
	}
}
