using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buttonica.Core.Framework
{

	/// <summary>
	///		Common contract for all engine components
	/// </summary>
	public interface IComponent
	{

		/// <summary>
		///		Returns the name of the component
		/// </summary>
		string Name { get; }

	}

}
