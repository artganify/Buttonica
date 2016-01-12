using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buttonica.Core.Logging
{

	/// <summary>
	///		Represents the common contract for loggers
	/// </summary>
	public interface ILogger
	{

		/// <summary>
		///		Writes the specified <see cref="LogEvent"/>
		/// </summary>
		void Write(LogEvent logEvent);

	}

}
