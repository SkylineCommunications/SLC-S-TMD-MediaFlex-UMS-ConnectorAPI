namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS
{
    /// <summary>
    /// Used to log information from the NuGet package.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs a line containing the name of the class, method and a message.
        /// </summary>
        /// <param name="nameOfClass">Name of the class from where the log originates.</param>
        /// <param name="nameOfMethod">Name of the method from where the log originates.</param>
        /// <param name="message">Log message.</param>
        void Log(string nameOfClass, string nameOfMethod, string message);
    }
}
