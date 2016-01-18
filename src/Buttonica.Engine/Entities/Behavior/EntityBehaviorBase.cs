using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buttonica.Engine.Core;

namespace Buttonica.Engine.Entities.Behavior
{

	/// <summary>
	///		Provides a base implementation of an <see cref="IEntityBehavior"/>
	/// </summary>
	public abstract class EntityBehaviorBase : EnableableComponentBase, IEntityBehavior
	{

		/// <summary>
		///		Returns the parent <see cref="EntityContainer"/>
		/// </summary>
		protected EntityContainer ParentContainer { get; }

		/// <summary>
		///		Creates a new <see cref="EntityBehaviorBase"/>, specifying the parent <see cref="EntityContainer"/>
		/// </summary>
		/// <param name="parentContainer"></param>
		protected EntityBehaviorBase(EntityContainer parentContainer)
		{
			Guard.AgainstNullArgument(nameof(parentContainer), parentContainer);
			ParentContainer = parentContainer;
		}

		/// <summary>
		///		Validates the specified <see cref="IEntity"/> and determines whether the entity needs to be added or removed
		/// </summary>
		protected abstract void ValidateEntity(IEntity entity, List<IEntityBehavior> behaviors, bool forceRemove = false);

		/// <summary>
		///		Invoked when the specified <see cref="IEntity"/> has been enabled
		/// </summary>
		protected virtual void OnEntityEnabled(IEntity entity)
		{

		}

		/// <summary>
		///		Invoked when the specified <see cref="IEntity"/> has been disabled
		/// </summary>
		protected virtual void OnEntityDisabled(IEntity entity)
		{

		}

		/// <summary>
		///		Enables the specified <see cref="IEntity"/>
		/// </summary>
		protected abstract void EnableEntity(IEntity entity);

		/// <summary>
		///		Disables the specified <see cref="IEntity"/>
		/// </summary>
		protected abstract void DisableEntity(IEntity entity);

		/// <summary>
		///		Internally registers the specified <see cref="IEntity"/> for the behavior by adding it to the parent <see cref="EntityContainer"/>
		/// </summary>
		protected void AddEntity(IEntity entity)
		{
			Guard.AgainstNullArgument(nameof(entity), entity);
			ParentContainer.AddEntity(entity);
		}

		/// <summary>
		///		Internally removes the specified <see cref="IEntity"/> from the behavior by removing it from the parent <see cref="EntityContainer"/>
		/// </summary>
		protected void RemoveEntity(IEntity entity)
		{
			Guard.AgainstNullArgument(nameof(entity), entity);
			ParentContainer.RemoveEntity(entity);
		}

	}

	/// <summary>
	///		Represents a strongly typed <see cref="IEntityBehavior"/> for tracking entities matching certain <see cref="IEntityComponent"/> requirements
	/// </summary>
	/// <typeparam name="TEntityComponent">Arbitary type implementing <see cref="IEntityComponent"/></typeparam>
	public abstract class EntityBehaviorBase<TEntityComponent> : EntityBehaviorBase
		where TEntityComponent : IEntityComponent
	{

		/// <summary>
		///		Returns a dictionary of currently enabled entities
		/// </summary>
		protected Dictionary<IEntity, TEntityComponent> EnabledEntities = new Dictionary<IEntity, TEntityComponent>();

		/// <summary>
		///		Returns a dictionary of entities suitable for this behavior
		/// </summary>
		protected Dictionary<IEntity, TEntityComponent> MatchingEntities = new Dictionary<IEntity, TEntityComponent>();

		/// <summary>
		///		Creates a new <see cref="EntityBehaviorBase"/>, specifying the parent <see cref="EntityContainer"/>
		/// </summary>
		protected EntityBehaviorBase(EntityContainer parentContainer) 
			: base(parentContainer)
		{
		}

		/// <summary>
		///		Returns whether the specified <see cref="IEntity"/> matches the criterias of this behavior
		/// </summary>
		protected virtual bool IsSatisfiedBy(IEntity entity)
		{
			return false;
		}

		/// <summary>
		///		Enables the specified <see cref="IEntity"/>
		/// </summary>
		protected override void EnableEntity(IEntity entity)
		{
			TEntityComponent entityComponent;
			if (!MatchingEntities.TryGetValue(entity, out entityComponent))
				throw new InvalidOperationException("Attempted to enable an unknown entity!");

			EnabledEntities.Add(entity, MatchingEntities[entity]);

			OnEntityEnabled(entity);
		}

		/// <summary>
		///		Disables the specified <see cref="IEntity"/>
		/// </summary>
		protected override void DisableEntity(IEntity entity)
		{
			if (!EnabledEntities.Remove(entity))
				throw new InvalidOperationException("Attempted to disable an unknown entity!");

			OnEntityDisabled(entity);
		}

		/// <summary>
		///		Validates the specified <see cref="IEntity"/> and determines whether the entity needs to be added or removed
		/// </summary>
		protected override void ValidateEntity(IEntity entity, List<IEntityBehavior> behaviors, bool forceRemove = false)
		{
			var isMatch = !forceRemove && IsSatisfiedBy(entity);

			TEntityComponent entityComponent;
			var isEntityAdded = MatchingEntities.TryGetValue(entity, out entityComponent);

			if (isMatch && !isEntityAdded)
			{
				// TODO what could we do if e.g. OnEntityAdded changes any entity components?

				entityComponent = ResolveEntityComponent(entity);
				behaviors.Add(this);

				MatchingEntities.Add(entity, entityComponent);

				if(ParentContainer.IsEnabled(entity))
					EnabledEntities.Add(entity, entityComponent);

				OnEntityAdded(entity, entityComponent);
			} else if (isEntityAdded && !isMatch) {
				OnEntityRemoved(entity, entityComponent);

				behaviors.Remove(this);

				EnabledEntities.Remove(entity);
				MatchingEntities.Remove(entity);
			} else if (isMatch) {

				if (MatchesResolvedComponent(entity, entityComponent)) 
					return;

				OnEntityRemoved(entity, entityComponent);
				entityComponent = ResolveEntityComponent(entity);
				OnEntityAdded(entity, entityComponent);

				MatchingEntities[entity] = entityComponent;
				if (ParentContainer.IsEnabled(entity))
					EnabledEntities[entity] = entityComponent;
			}
		}

		/// <summary>
		///		Resolves an entity component for the specified entity
		/// </summary>
		protected abstract TEntityComponent ResolveEntityComponent(IEntity entity);

		/// <summary>
		///		Returns whether the resolved entity component is still valid or if re-adding is required
		/// </summary>
		/// <returns></returns>
		protected virtual bool MatchesResolvedComponent(IEntity entity, TEntityComponent associatedData) => ResolveEntityComponent(entity).Equals(associatedData);

		/// <summary>
		///		Invoked when a matching entity has been added to this behavior
		/// </summary>
		protected virtual void OnEntityAdded(IEntity entity, TEntityComponent component)
		{
			
		}

		/// <summary>
		///		Invoked when a matching entity is removed from this behavior
		/// </summary>
		protected virtual void OnEntityRemoved(IEntity entity, TEntityComponent component)
		{
			
		}

	}

}
