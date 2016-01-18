using System;

namespace Buttonica.Engine.Core
{
	/// <summary>
	///     Represents a uniquely identifyable type
	/// </summary>
	public interface IIdentifyable
	{
		/// <summary>
		///     Returns the unique id of the instance
		/// </summary>
		Guid Id { get; }
	}
}