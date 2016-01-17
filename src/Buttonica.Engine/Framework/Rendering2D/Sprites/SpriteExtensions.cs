using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Buttonica.Engine.Framework.Rendering2D.Sprites
{
	/// <summary>
	///     Extensions for <see cref="Sprite" />
	/// </summary>
	public static class SpriteExtensions
	{
		/// <summary>
		///     Draws a <see cref="Sprite" /> using the specified <see cref="SpriteBatch" />
		/// </summary>
		public static void Draw(this SpriteBatch spriteBatch, Sprite spriteRegion, Vector2 position, Color color)
		{
			Guard.AgainstNullArgument(nameof(spriteBatch), spriteBatch);
			spriteBatch.Draw(spriteRegion.Texture, position, spriteRegion.Bounds, color);
		}

		/// <summary>
		///     Draws a <see cref="Sprite" /> using the specified <see cref="SpriteBatch" />
		/// </summary>
		public static void Draw(this SpriteBatch spriteBatch, Sprite spriteRegion, Rectangle destination, Color color)
		{
			Guard.AgainstNullArgument(nameof(spriteBatch), spriteBatch);
			spriteBatch.Draw(spriteRegion.Texture, destination, spriteRegion.Bounds, color);
		}
	}
}