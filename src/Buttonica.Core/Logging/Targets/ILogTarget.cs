using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buttonica.Core.Logging.Targets
{

	/// <summary>
	///		Represents a destination for <see cref="LogEvent">log events</see>
	/// </summary>
	public interface ILogTarget
	{

		/// <summary>
		///		Emits the specified <see cref="LogEvent"/>
		/// </summary>
		void Emit(LogEvent logEvent);

	}
}
