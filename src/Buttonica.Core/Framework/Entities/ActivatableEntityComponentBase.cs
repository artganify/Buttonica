using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buttonica.Core.Framework.Entities
{
	public abstract class ActivatableEntityComponentBase : EntityComponentBase
	{

		/// <summary>
		///		Gets or sets whether the component is enabled
		/// </summary>
		public bool IsEnabled { get; set; } = true; // components are enabled by default

		/// <summary>
		///		Creates a new <see cref="ActivatableEntityComponentBase"/> specifying it's owner
		/// </summary>
		protected ActivatableEntityComponentBase(EntityBase owner) 
			: base(owner)
		{
		}

	}
}
