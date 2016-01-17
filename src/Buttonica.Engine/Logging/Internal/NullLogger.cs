namespace Buttonica.Engine.Logging.Internal
{
	internal class NullLogger : ILogger
	{
		public static NullLogger Instance = new NullLogger();

		public void Write(LogEvent logEvent)
		{
			// do nothing
		}
	}
}