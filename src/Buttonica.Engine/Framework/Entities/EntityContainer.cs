using System.Collections;
using System.Collections.Generic;
using Buttonica.Engine.Framework.Core;

namespace Buttonica.Engine.Framework.Entities
{
	/// <summary>
	///     Represents a container of entities
	/// </summary>
	public class EntityContainer : ComponentBase, IEnumerable<IEntity>
	{
		/// <summary>
		///     Returns all entities within this container
		/// </summary>
		public HashSet<IEntity> Entities { get; } = new HashSet<IEntity>();

		/// <summary>
		///     Returns an enumerator that iterates through the collection.
		/// </summary>
		public IEnumerator<IEntity> GetEnumerator() => Entities.GetEnumerator();

		/// <summary>
		///     Returns an enumerator that iterates through a collection.
		/// </summary>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		/// <summary>
		///     Adds the specified entity to the container
		/// </summary>
		public void AddEntity(IEntity entity)
		{
			Guard.AgainstNullArgument(nameof(entity), entity);

			Entities.Add(entity);
			OnEntityAdded(entity);
		}

		/// <summary>
		///     Removes the specified entity from the container
		/// </summary>
		public void RemoveEntity(IEntity entity)
		{
			Guard.AgainstNullArgument(nameof(entity), entity);

			Entities.Remove(entity);
			OnEntityRemoved(entity);
		}

		/// <summary>
		///     Invoked when an entity has been added to the container
		/// </summary>
		protected virtual void OnEntityAdded(IEntity addedEntity)
		{
		}

		/// <summary>
		///     Invoked when an entity has been removed from the container
		/// </summary>
		protected virtual void OnEntityRemoved(IEntity removedEntity)
		{
		}
	}
}