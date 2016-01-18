using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Buttonica.Engine.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Buttonica.Engine.Graphics.Sprites
{
	/// <summary>
	///     Represents a sprite texture splitted into regions (texture atlas)
	/// </summary>
	public class SpriteSheet : ComponentBase, IEnumerable<Sprite>
	{
		private readonly List<Sprite> _sprites = new List<Sprite>();

		/// <summary>
		///     Returns the <see cref="Sprite" /> at the specified index
		/// </summary>
		public Sprite this[int index] => GetSpriteByIndex(index);

		/// <summary>
		///     Returns the <see cref="Texture2D" /> of the current <see cref="SpriteSheet" />
		/// </summary>
		public Texture2D Texture { get; }

		/// <summary>
		///     Returns all regions within this <see cref="SpriteSheet" />
		/// </summary>
		public IEnumerable<Sprite> Sprites => _sprites.AsReadOnly().AsEnumerable();

		/// <summary>
		///     Creates a new <see cref="SpriteSheet" /> using the specified <see cref="Texture" />
		/// </summary>
		public SpriteSheet(Texture2D texture)
		{
			Texture = texture;
		}

		/// <summary>
		///     Returns an enumerator that iterates through the collection.
		/// </summary>
		public IEnumerator<Sprite> GetEnumerator() => _sprites.GetEnumerator();

		/// <summary>
		///     Returns an enumerator that iterates through a collection.
		/// </summary>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		/// <summary>
		///     Returns the <see cref="Sprite" /> at the specified index
		/// </summary>
		public Sprite GetSpriteByIndex(int index)
		{
			Guard.Requires(index > 0 && index <= _sprites.Count, () => new IndexOutOfRangeException());
			return _sprites[index];
		}

		/// <summary>
		///     Creates a new <see cref="Sprite" /> using the specified coordinates, width and height
		/// </summary>
		/// <returns></returns>
		public Sprite CreateSprite(int x, int y, int width, int height) => CreateSprite(new Rectangle(x, y, width, height));

		/// <summary>
		///     Creates a new <see cref="Sprite" /> using the specified boundaries
		/// </summary>
		public Sprite CreateSprite(Rectangle bounds)
		{
			var region = new Sprite(Texture, bounds);
			_sprites.Add(region);

			return region;
		}

		/// <summary>
		///     Creates a new <see cref="SpriteSheet" /> from the specified <see cref="Texture2D" />, sprite width, sprite height
		///     and optional margin as well as spacing values
		/// </summary>
		public static SpriteSheet Create(Texture2D texture, int spriteWidth, int spriteHeight, int margin = 0, int spacing = 0)
		{
			var spriteSheet = new SpriteSheet(texture);
			var width = texture.Width - margin;
			var height = texture.Height - margin;

			for (var y = margin; y < height; y += (spriteHeight + spacing))
			{
				for (var x = margin; x < width; x += (spriteWidth + spacing))
				{
					spriteSheet.CreateSprite(x, y, spriteWidth, spriteHeight);
				}
			}

			return spriteSheet;
		}
	}
}