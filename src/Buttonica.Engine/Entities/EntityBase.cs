using System;
using System.Collections.Generic;
using System.Linq;
using Buttonica.Engine.Core;

namespace Buttonica.Engine.Entities
{
	/// <summary>
	///     Provides a base class for all entities within the world space
	/// </summary>
	public abstract class EntityBase : EnableableComponentBase, IEntity
	{
		private readonly List<IEntityComponent> _components = new List<IEntityComponent>();

		/// <summary>
		///     Returns the id of the entity
		/// </summary>
		public Guid Id { get; } = new Guid();

		/// <summary>
		///     Returns a list of components of this entity
		/// </summary>
		public IEnumerable<IEntityComponent> Components => _components.AsReadOnly().AsEnumerable();

		/// <summary>
		///     Adds the specified component to this entity
		/// </summary>
		public void AddComponent(IEntityComponent component)
		{
			Guard.AgainstNullArgument(nameof(component), component);

			_components.Add(component);
			OnComponentAdded(component);
		}

		/// <summary>
		///     Inserts the component at the specified index
		/// </summary>
		public void InsertComponent(int index, IEntityComponent component)
		{
			Guard.AgainstNullArgument(nameof(component), component);

			_components.Insert(index, component);
			OnComponentAdded(component);
		}

		/// <summary>
		///     Inserts a component before a specified component
		/// </summary>
		public void InsertBeforeComponent(IEntityComponent other, IEntityComponent component)
			=> InsertComponent(_components.IndexOf(other), component);

		/// <summary>
		///     Inserts a component after a specified component
		/// </summary>
		public void InsertAfterComponent(IEntityComponent other, IEntityComponent component)
			=> InsertComponent(_components.IndexOf(other) + 1, component);

		/// <summary>
		///     Inserts a component at the beginning of the collection
		/// </summary>
		public void InsertComponentAtFirst(IEntityComponent component) => InsertComponent(0, component);

		/// <summary>
		///     Inserts a component at the end of the collection
		/// </summary>
		public void InsertComponentAtLast(IEntityComponent component) => InsertComponent(_components.Count - 1, component);

		/// <summary>
		///     Removes the specified component from this entity
		/// </summary>
		public void RemoveComponent(IEntityComponent component)
		{
			Guard.AgainstNullArgument(nameof(component), component);

			_components.Remove(component);
			OnComponentRemoved(component);
		}

		/// <summary>
		///     Removes all components from the entity
		/// </summary>
		public void ClearComponents()
		{
			for (var i = _components.Count; i >= 0; i--)
				RemoveComponent(_components[i]);
		}

		/// <summary>
		///     Invoked when the component has been enabled
		/// </summary>
		protected override void OnEnabled()
		{
			// enable all components (which can be enabled, some might be locked)
			var enableableComponents = new List<EnableableComponentBase>();
			lock (Components)
				enableableComponents.AddRange(Components.OfType<EnableableComponentBase>());

			foreach (var enableableComponent in enableableComponents)
				enableableComponent.IsEnabled = true;

			base.OnEnabled();
		}

		/// <summary>
		///     Invoked when the component has been disabled
		/// </summary>
		protected override void OnDisabled()
		{
			// disable all components (which can be disabled, some might be locked)
			var disableableComponents = new List<EnableableComponentBase>();
			lock (Components)
				disableableComponents.AddRange(Components.OfType<EnableableComponentBase>());

			foreach (var disableableComponent in disableableComponents)
				disableableComponent.IsEnabled = false;

			base.OnDisabled();
		}

		/// <summary>
		///     Invoked when a component has been added to the entity
		/// </summary>
		protected virtual void OnComponentAdded(IComponent addedComponent)
		{
		}

		/// <summary>
		///     Invoked when a component has been removed from the entity
		/// </summary>
		protected virtual void OnComponentRemoved(IComponent removedComponent)
		{
		}
	}
}