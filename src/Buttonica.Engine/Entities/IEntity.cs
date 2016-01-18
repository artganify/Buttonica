using System.Collections.Generic;
using Buttonica.Engine.Core;

namespace Buttonica.Engine.Entities
{
	/// <summary>
	///     Common contract for all entities within the world space. An entity is a uniquely identifable game object
	///     which maintains a collection of <see cref="IEntityComponent">entity components</see>.
	/// </summary>
	public interface IEntity : IComponent, IIdentifyable
	{
		/// <summary>
		///     Returns whether the entity is currently enabled
		/// </summary>
		bool IsEnabled { get; }

		/// <summary>
		///     Returns a list of components of this entity
		/// </summary>
		IEnumerable<IEntityComponent> Components { get; }
	}
}