using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buttonica.Core.Framework.Core;
using Microsoft.Xna.Framework;

namespace Buttonica.Core.Framework.Entities
{

	/// <summary>
	///		Base class for all entities within the world space
	/// </summary>
	public abstract class EntityBase : ComponentBase, IIdentifable
	{

		private bool _isEnabled = true;

		/// <summary>
		///		Returns the id of the entity
		/// </summary>
		public Guid Id { get; } = new Guid();

		/// <summary>
		///		Returns all components of the current entity
		/// </summary>
		public List<EntityComponentBase> Components { get; } = new List<EntityComponentBase>(); 

		/// <summary>
		///		Gets or sets whether the entity is currently enabled
		/// </summary>
		public bool IsEnabled {
			get { return _isEnabled; }
			set
			{
				if(value == _isEnabled)
					return;

				// update all compontents
				foreach (
					var component in
						Components.Where(component => 
						component is ActivatableEntityComponentBase).Cast<ActivatableEntityComponentBase>())
					component.IsEnabled = value;

				if(value)
					OnEnabling();
				else
					OnDisabling();

				_isEnabled = value;
			}
		}

		/// <summary>
		///		Invoked during disposal of managed resources
		/// </summary>
		protected override void OnManagedDisposal()
		{
			base.OnManagedDisposal();

			IsEnabled = false;
		}

		/// <summary>
		///		Invoked when the entity is being enabled
		/// </summary>
		protected virtual void OnEnabling()
		{
			
		}

		/// <summary>
		///		Invoked when the entity is being disabled
		/// </summary>
		protected virtual void OnDisabling()
		{
			
		}

	}

}
