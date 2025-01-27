namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS
{
    /// <summary>
    /// Defines some of the key Parameter Ids used for communicating with a TMD MediaFlex UMS element running the 2.0.0.X range.
    /// </summary>
    public static class TmdMediaFlexUmsProtocol
    {
        /// <summary>
        /// Name of the protocol.
        /// </summary>
        public static readonly string Name = "TMD MediaFlex UMS";

		/// <summary>
		/// ID of the parameter that receives the message from the web service.
		/// </summary>
		public static readonly int LastNotificationPid = 10;

        /// <summary>
        /// ID of the read parameter containing the Timeout value in seconds used for all InterApp communication to the element.
        /// </summary>
        public static readonly int InterAppTimeoutPid = 250;

        /// <summary>
        /// ID of the read parameter to on which all InterApp messages are received.
        /// </summary>
        public static readonly int InterAppReceivePid = 9000000;

		/// <summary>
		/// Represent the File Status Update table.
		/// </summary>
		public static class FileStatusUpdatesTable
		{
			/// <summary>
			/// ID of the table parameter.
			/// </summary>
			public static readonly int TablePid = 1000;

			/// <summary>
			/// Parameter IDs of columns.
			/// </summary>
			public static class Pid
			{
				/// <summary>
				/// Parameter ID of the reconcile key column.
				/// </summary>
				public static readonly int ReconcileKeyId = 2110;
			}

			/// <summary>
			/// Parameter indexes of columns.
			/// </summary>
			public static class Idx
			{
				/// <summary>
				/// 
				/// </summary>
				public static readonly int Id = 0;


				/// <summary>
				/// 
				/// </summary>
				public static readonly int PlasmaId = 1;


				/// <summary>
				/// 
				/// </summary>
				public static readonly int Timestamp = 2;


				/// <summary>
				/// 
				/// </summary>
				public static readonly int Type = 3;


				/// <summary>
				/// 
				/// </summary>
				public static readonly int Status = 4;


				/// <summary>
				/// 
				/// </summary>
				public static readonly int Description = 5;
			}
		}
	}
}
