using Buttonica.Engine.Framework.Core;

namespace Buttonica.Engine.Framework.Entities
{
	/// <summary>
	///     Provides a base implementation of <see cref=" IEntityComponent" />
	/// </summary>
	public abstract class EntityComponentBase : EnableableComponentBase, IEntityComponent
	{
		/// <summary>
		///     Returns the owner of this component
		/// </summary>
		protected IEntity Owner { get; }

		/// <summary>
		///     Creates a new <see cref="EntityComponentBase" /> specifying it's owner entity
		/// </summary>
		protected EntityComponentBase(IEntity owner)
		{
			Guard.AgainstNullArgument(nameof(owner), owner);
			Owner = owner;
		}
	}
}