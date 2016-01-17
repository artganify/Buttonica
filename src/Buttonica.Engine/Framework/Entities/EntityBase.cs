using System;
using System.Collections.Generic;
using Buttonica.Engine.Framework.Core;

namespace Buttonica.Engine.Framework.Entities
{
	/// <summary>
	///     Provides a base class for all entities within the world space
	/// </summary>
	public abstract class EntityBase : ComponentBase, IEntity
	{
		/// <summary>
		///     Returns the id of the entity
		/// </summary>
		public Guid Id { get; } = new Guid();

		/// <summary>
		///     Returns a list of components of this entity
		/// </summary>
		public ICollection<IEntityComponent> Components { get; } = new List<IEntityComponent>();
	}
}