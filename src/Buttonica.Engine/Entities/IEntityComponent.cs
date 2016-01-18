using Buttonica.Engine.Core;

namespace Buttonica.Engine.Entities
{
	/// <summary>
	///     Represents the common contract for all entity components
	/// </summary>
	public interface IEntityComponent : IComponent
	{
		/// <summary>
		///     Returns whether the component is currently enabled
		/// </summary>
		bool IsEnabled { get; }
	}
}