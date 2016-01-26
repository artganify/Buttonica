using System;
using System.IO;

namespace Pressiah.Diagnostics.Logging.Targets
{
    /// <summary>
    ///     Implementation of a <see cref="ILogTarget" /> which allows writing to a file
    /// </summary>
    public class FileLogTarget : ILogTarget, IDisposable
    {
        private readonly object _mutex = new object();
        private readonly TextWriter _writer;

        private bool _isDisposed;

        /// <summary>
        ///     Creates a new <see cref="FileLogTarget" /> specifying the file log path
        /// </summary>
        public FileLogTarget(string path)
        {
            _guard.AgainstNullArgument(nameof(path), path);

            // ensure log directory exists
            var directory = Path.GetDirectoryName(path);
            if (!string.IsNullOrWhiteSpace(directory) && !Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            var file = File.Open(path, FileMode.Create, FileAccess.Write, FileShare.Read);
            _writer = new StreamWriter(file);
        }

        /// <summary>
        ///     Disposes the file log target
        /// </summary>
        public void Dispose()
        {
            if (_isDisposed)
                return;

            // set isDisposed before actually disposing
            _isDisposed = true;
            _writer.Dispose();
        }

        /// <summary>
        ///     Emits the specified <see cref="LogEvent" />
        /// </summary>
        public void Emit(LogEvent logEvent)
        {
            if (_isDisposed)
                return;

            _guard.AgainstNullArgument(nameof(logEvent), logEvent);
            lock (_mutex)
            {
                _writer.WriteLine($"{logEvent.Timestamp} [{logEvent.Level}] {logEvent.Message}");
                if (logEvent.Exception != null)
                    _writer.WriteLine(logEvent.Exception.ToString());
                _writer.Flush();
            }
        }
    }
}