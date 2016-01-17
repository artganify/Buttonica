using System.Collections.Generic;
using Buttonica.Engine.Logging.Targets;

namespace Buttonica.Engine.Logging.Internal
{
	internal class Logger : ILogger
	{
		private readonly List<ILogTarget> _targets = new List<ILogTarget>();

		public Logger(IEnumerable<ILogTarget> targets)
		{
			if (targets == null)
				return;

			_targets.AddRange(targets);
		}

		public void Write(LogEvent logEvent)
		{
			if (logEvent == null)
				return;

			foreach (var target in _targets)
			{
				try
				{
					target.Emit(logEvent);
				}
				catch
				{
					// ignore
				}
			}
		}
	}
}