using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Buttonica.Engine.Core;
using Buttonica.Engine.Entities.Behavior;

namespace Buttonica.Engine.Entities
{
	/// <summary>
	///     Represents a container of <see cref="IEntity">entities</see>
	/// </summary>
	public class EntityContainer : ComponentBase, IEnumerable<IEntity>
	{

		/// <summary>
		///		Invoked when an <see cref="IEntity"/> has been added to the container
		/// </summary>
		public EventHandler<IEntity> EntityAdded;

		/// <summary>
		///		Invoked when an <see cref="IEntity"/> has been removed from the container
		/// </summary>
		public EventHandler<IEntity> EntityRemoved;


		private readonly Dictionary<IEntity, List<IEntityBehavior>>		_entities				= new Dictionary<IEntity, List<IEntityBehavior>>(); 
		private readonly HashSet<IEntity>								_enabledEntites			= new HashSet<IEntity>();
		private readonly List<IEntityBehavior>							_behaviors				= new List<IEntityBehavior>();
		private readonly List<IEntityBehavior>							_newBehaviors			= new List<IEntityBehavior>(); 
		private readonly HashSet<Type>									_behaviorTypes			= new HashSet<Type>();
		private readonly HashSet<Type>									_entityComponentTypes	= new HashSet<Type>();

		/// <summary>
		///		Returns a collection of registered <see cref="IEntityBehavior">entity behaviors</see>
		/// </summary>
		public IEnumerable<IEntityBehavior> EntityBehaviors => _behaviors;

		/// <summary>
		///		Returns a collection of entity component types
		/// </summary>
		public IEnumerable<Type> EntityComponentTypes => _entityComponentTypes; 

		/// <summary>
		///     Returns an enumerator that iterates through the collection.
		/// </summary>
		public IEnumerator<IEntity> GetEnumerator() => _entities.Keys.GetEnumerator();

		/// <summary>
		///     Returns an enumerator that iterates through a collection.
		/// </summary>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public void AddBehavior(IEntityBehavior entityBehavior)
		{
			Guard.AgainstNullArgument(nameof(entityBehavior), entityBehavior);

			if(!)
		}

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
		///		Returns whether the specified entity is currently enabled
		/// </summary>
		public bool IsEnabled(IEntity entity)
		{
			// ??? TODO
			return false;
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

		private void OnBehaviorAdded(IEntityBehavior entityBehavior)
		{
			_behaviorTypes.Add(entityBehavior.GetType());
		}

		private void OnBehaviorRemoved(IEntityBehavior entityBehavior)
		{
			
		}
	}
}