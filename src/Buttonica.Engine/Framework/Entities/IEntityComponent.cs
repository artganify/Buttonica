using Buttonica.Engine.Framework.Core;

namespace Buttonica.Engine.Framework.Entities
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