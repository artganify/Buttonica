using System.Collections.Generic;
using Buttonica.Engine.Logging.Internal;
using Buttonica.Engine.Logging.Targets;

namespace Buttonica.Engine.Logging.Configuration
{
	/// <summary>
	///     Represents a fluent factory for creating an instance of <see cref="ILogger" />
	/// </summary>
	public class LoggerBuilder
	{
		private readonly List<ILogTarget> _targets = new List<ILogTarget>();

		/// <summary>
		///     Registers the specified <see cref="ILogTarget" /> within the builder
		/// </summary>
		public void AddTarget(ILogTarget target)
		{
			Guard.AgainstNullArgument(nameof(target), target);
			_targets.Add(target);
		}

		/// <summary>
		///     Builds a new instance of <see cref="ILogger" />
		/// </summary>
		public ILogger Build() => new Logger(_targets);
	}
}