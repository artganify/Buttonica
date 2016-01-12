using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buttonica.Core.Logging.Targets;

namespace Buttonica.Core.Logging.Internal
{
	internal class Logger : ILogger
	{

		private readonly List<ILogTarget> _targets = new List<ILogTarget>(); 

		public Logger(IEnumerable<ILogTarget> targets)
		{
			if(targets == null)
				return;

			_targets.AddRange(targets);
		}

		public void Write(LogEvent logEvent)
		{
			if(logEvent == null)
				return;

			foreach (var target in _targets)
			{
				try {
					target.Emit(logEvent);
				} catch {
					// ignore
				}
			}
		}

	}
}
