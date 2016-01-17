using Buttonica.Engine.Logging.Internal;

namespace Buttonica.Engine.Logging
{
	/// <summary>
	///     Static accessor for the logging facility
	/// </summary>
	public static class Log
	{
		private static ILogger _Logger;

		/// <summary>
		///     Returns the currently registered <see cref="ILogger" />
		/// </summary>
		public static ILogger Logger
		{
			get { return _Logger ?? NullLogger.Instance; }
			set { _Logger = value; }
		}
	}
}