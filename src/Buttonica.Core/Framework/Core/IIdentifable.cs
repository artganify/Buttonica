using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buttonica.Core.Framework
{

	/// <summary>
	///		Contract for uniquely identifiable types
	/// </summary>
	public interface IIdentifable
	{

		/// <summary>
		///		Returns the id of the instance
		/// </summary>
		Guid Id { get; }

	}
}
