using Pressiah.Diagnostics.Logging.Internal;

namespace Pressiah.Diagnostics.Logging
{
    /// <summary>
    ///     Static accessor for the logging facility
    /// </summary>
    public static class Log
    {
        private static ILogger _logger;

        /// <summary>
        ///     Returns the currently registered <see cref="ILogger" />
        /// </summary>
        public static ILogger Logger
        {
            get { return _logger ?? NullLogger.Instance; }
            set { _logger = value; }
        }
    }
}