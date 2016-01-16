using Buttonica.Core.Framework.Core.Types;
using Microsoft.Xna.Framework.Graphics;

namespace Buttonica.Core.Framework.Rendering2D.Sprites
{

	/// <summary>
	///		Represents a sprite within the world space, which is a 2 dimensional image or animation
	/// </summary>
	public class Sprite : Entity2D
	{

		private Texture2D _texture;

		/// <summary>
		///		Gets or sets the texture of the current sprite
		/// </summary>
		public Texture2D Texture
		{
			get { return _texture; }
			set
			{
				_texture = value;
				OnTextureChanged();
			}
		}

		/// <summary>
		///		Creates a new <see cref="Sprite"/>
		/// </summary>
		protected Sprite()
			: base(RectangleF.Empty)
		{
			
		}

		/// <summary>
		///		Creates a new <see cref="Sprite"/> with the specified <see cref="Texture2D"/> and draw area
		/// </summary>
		public Sprite(Texture2D texture, RectangleF drawArea)
			: base(drawArea)
		{
			_texture = texture;
		}

		/// <summary>
		///		Creates a new <see cref="Sprite"/> with the specified <see cref="SpriteRegion"/> and draw area
		/// </summary>
		public Sprite(SpriteRegion spriteRegion, RectangleF drawArea)
			: this(spriteRegion.Texture, drawArea)
		{
			
		}

		/// <summary>
		///		Invoked when the texture of the sprite has changed
		/// </summary>
		protected virtual void OnTextureChanged()
		{
			
		}

	}
}
