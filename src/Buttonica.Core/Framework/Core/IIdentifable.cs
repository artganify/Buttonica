using System;

namespace Buttonica.Core.Framework.Core
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
