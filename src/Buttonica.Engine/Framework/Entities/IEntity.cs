using System.Collections.Generic;
using Buttonica.Engine.Framework.Core;

namespace Buttonica.Engine.Framework.Entities
{
	/// <summary>
	///     Common contract for all entities within the world space. An entity is a uniquely identifable game object
	///     which maintains a collection of <see cref="IEntityComponent">entity components</see>.
	/// </summary>
	public interface IEntity : IComponent, IIdentifyable
	{
		/// <summary>
		///     Returns a list of components of this entity
		/// </summary>
		// TODO do we need to expose this?
		ICollection<IEntityComponent> Components { get; }
	}
}