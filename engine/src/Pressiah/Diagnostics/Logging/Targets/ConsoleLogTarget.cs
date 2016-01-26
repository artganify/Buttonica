using System;

namespace Pressiah.Diagnostics.Logging.Targets
{
    /// <summary>
    ///     Provides an implementation of <see cref="ILogTarget" /> for the default system console
    /// </summary>
    public class ConsoleLogTarget : ILogTarget
    {
        private readonly object _mutex = new object();

        /// <summary>
        ///     Emits the specified <see cref="LogEvent" />
        /// </summary>
        public void Emit(LogEvent logEvent)
        {
            _guard.AgainstNullArgument(nameof(logEvent), logEvent);

            var writer = Console.Out;
            lock (_mutex)
            {
                var previousColor = Console.ForegroundColor;
                var currentColor = GetConsoleColorFromLevel(logEvent.Level);

                Console.ForegroundColor = currentColor;
                writer.WriteLine($"{logEvent.Timestamp} [{logEvent.Level}] {logEvent.Message}");
                if (logEvent.Exception != null)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    writer.WriteLine(logEvent.Exception.ToString());
                }

                // reset color
                Console.ForegroundColor = previousColor;
            }
        }

        private static ConsoleColor GetConsoleColorFromLevel(LogEventLevel level)
        {
            switch (level)
            {
                case LogEventLevel.Trace:
                    return ConsoleColor.Gray;
                case LogEventLevel.Debug:
                    return ConsoleColor.Cyan;
                case LogEventLevel.Information:
                    return ConsoleColor.White;
                case LogEventLevel.Warning:
                    return ConsoleColor.DarkYellow;
                case LogEventLevel.Error:
                    return ConsoleColor.Yellow;
                case LogEventLevel.Fatal:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.DarkGray;
            }
        }
    }
}