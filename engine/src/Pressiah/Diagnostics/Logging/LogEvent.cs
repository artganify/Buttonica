using System;

namespace Pressiah.Diagnostics.Logging
{
    /// <summary>
    ///     Represents the payload of an application event
    /// </summary>
    public class LogEvent
    {
        /// <summary>
        ///     Returns the <see cref="LogEventLevel" /> of the current event
        /// </summary>
        public LogEventLevel Level { get; }

        /// <summary>
        ///     Returns the message of the current event
        /// </summary>
        public string Message { get; }

        /// <summary>
        ///     Returns the timestamp of the current event
        /// </summary>
        public DateTimeOffset Timestamp { get; }

        /// <summary>
        ///     Returns an exception associated with the current event
        /// </summary>
        public Exception Exception { get; }

        /// <summary>
        ///     Creates a new <see cref="LogEvent" />
        /// </summary>
        public LogEvent(DateTimeOffset timestamp, LogEventLevel level, Exception exception, string message)
        {
            Timestamp = timestamp;
            Level = level;
            Exception = exception;
            Message = message;
        }

        /// <summary>
        ///     Creates a new <see cref="LogEvent" />
        /// </summary>
        public LogEvent(LogEventLevel level, Exception exception, string message)
            : this(DateTimeOffset.UtcNow, level, exception, message)
        {
        }

        /// <summary>
        ///     Creates a new <see cref="LogEvent" />
        /// </summary>
        public LogEvent(LogEventLevel level, string message)
            : this(level, null, message)
        {
        }

        /// <summary>
        ///     Creates a new <see cref="LogEvent" />
        /// </summary>
        public LogEvent(LogEventLevel level, Exception exception)
            : this(level, exception, exception.Message)
        {
        }
    }
}