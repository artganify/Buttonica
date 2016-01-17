using Buttonica.Engine.Framework.Entities;
using Microsoft.Xna.Framework;

namespace Buttonica.Engine.Framework.Rendering2D.Sprites
{
	/// <summary>
	///     Represents an entity component for sprites
	/// </summary>
	public sealed class SpriteComponent : EntityComponentBase
	{
		/// <summary>
		///     Gets or sets the color to apply on the sprite
		/// </summary>
		public Color Color { get; set; } = Color.White;

		/// <summary>
		///     Gets or sets the <see cref="ISpriteProvider" /> for this component
		/// </summary>
		public ISpriteProvider SpriteProvider { get; set; }

		/// <summary>
		///     Gets or sets the current frame
		/// </summary>
		public int CurrentFrame { get; set; }

		/// <summary>
		///     Returns the current sprite
		/// </summary>
		public Sprite Sprite => SpriteProvider.GetSpriteByIndex(CurrentFrame);

		/// <summary>
		///     Creates a new <see cref="SpriteComponent" /> specifying it's owner
		/// </summary>
		public SpriteComponent(IEntity owner, ISpriteProvider spriteProvider)
			: base(owner)
		{
			Guard.AgainstNullArgument(nameof(spriteProvider), spriteProvider);
			SpriteProvider = spriteProvider;
		}
	}
}