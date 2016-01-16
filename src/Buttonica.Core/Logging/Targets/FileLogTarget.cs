using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buttonica.Core.Logging.Targets
{

	/// <summary>
	///		Implementation of a <see cref="ILogTarget"/> which allows writing to a file
	/// </summary>
	public class FileLogTarget : ILogTarget, IDisposable
	{

		private readonly object			_mutex = new object();
		private readonly TextWriter		_writer;

		private bool _isDisposed;

		/// <summary>
		///		Creates a new <see cref="FileLogTarget"/> specifying the file log path
		/// </summary>
		public FileLogTarget(string path)
		{
			Guard.AgainstNullArgument(nameof(path), path);

			// ensure log directory exists
			var directory = Path.GetDirectoryName(path);
			if (!string.IsNullOrWhiteSpace(directory) && !Directory.Exists(directory))
				Directory.CreateDirectory(directory);

			var file	= File.Open(path, FileMode.Create, FileAccess.Write, FileShare.Read);
			_writer		= new StreamWriter(file);
		}

		/// <summary>
		///		Emits the specified <see cref="LogEvent"/>
		/// </summary>
		public void Emit(LogEvent logEvent)
		{
			if(_isDisposed)
				return;

			Guard.AgainstNullArgument(nameof(logEvent), logEvent);
			lock (_mutex)
			{
				_writer.WriteLine($"{logEvent.Timestamp} [{logEvent.Level}] {logEvent.Message}");
				if(logEvent.Exception != null)
					_writer.WriteLine(logEvent.Exception.ToString());
				_writer.Flush();
			}
		}

		/// <summary>
		///		Disposes the file log target
		/// </summary>
		public void Dispose()
		{
			if(_isDisposed)
				return;

			// set isDisposed before actually disposing
			_isDisposed = true;
			_writer.Dispose();
		}
	}
}
