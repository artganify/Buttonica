using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Buttonica.Core.Framework.Rendering2D.Sprites
{

	/// <summary>
	///		Extensions for <see cref="SpriteRegion"/>
	/// </summary>
	public static class SpriteRegionExtensions
	{

		/// <summary>
		///		Draws a <see cref="SpriteRegion"/> using the specified <see cref="SpriteBatch"/>
		/// </summary>
		public static void Draw(this SpriteBatch spriteBatch, SpriteRegion spriteRegion, Vector2 position, Color color)
		{
			Guard.AgainstNullArgument(nameof(spriteBatch), spriteBatch);
			spriteBatch.Draw(spriteRegion.Texture, position, spriteRegion.Bounds, color);
		}

		/// <summary>
		///		Draws a <see cref="SpriteRegion"/> using the specified <see cref="SpriteBatch"/>
		/// </summary>
		public static void Draw(this SpriteBatch spriteBatch, SpriteRegion spriteRegion, Rectangle destination, Color color)
		{
			Guard.AgainstNullArgument(nameof(spriteBatch), spriteBatch);
			spriteBatch.Draw(spriteRegion.Texture, destination, spriteRegion.Bounds, color);
		}

	}

}
