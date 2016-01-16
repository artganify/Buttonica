using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buttonica.Core.Framework.Core;

namespace Buttonica.Core.Framework.Entities
{

	/// <summary>
	///		Provides a base class of components of an <see cref="EntityBase"/>
	/// </summary>
	public abstract class EntityComponentBase : ComponentBase
	{

		/// <summary>
		///		Returns the owner of this component
		/// </summary>
		protected EntityBase Owner { get; }

		/// <summary>
		///		Creates a new <see cref="EntityComponentBase"/> specifying it's owner
		/// </summary>
		/// <param name="owner"></param>
		protected EntityComponentBase(EntityBase owner)
		{
			Guard.AgainstNullArgument(nameof(owner), owner);
			Owner = owner;
		}

	}

}
