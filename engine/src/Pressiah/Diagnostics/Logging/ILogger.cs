namespace Pressiah.Diagnostics.Logging
{
    /// <summary>
    ///     Represents the common contract for loggers
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        ///     Writes the specified <see cref="LogEvent" />
        /// </summary>
        void Write(LogEvent logEvent);
    }
}