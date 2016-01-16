using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Buttonica.Core.Framework.Rendering2D.Sprites
{

	/// <summary>
	///		Represents a sprite texture splitted into regions (texture atlas)
	/// </summary>
	public class SpriteSheet : IEnumerable<SpriteRegion>
	{

		private readonly List<SpriteRegion> _regions = new List<SpriteRegion>();

		/// <summary>
		///		Returns the <see cref="SpriteRegion"/> at the specified index
		/// </summary>
		public SpriteRegion this[int index] => GetRegionByIndex(index);

		/// <summary>
		///		Returns the <see cref="Texture2D"/> of the current <see cref="SpriteSheet"/>
		/// </summary>
		public Texture2D Texture { get; }

		/// <summary>
		///		Creates a new <see cref="SpriteSheet"/> using the specified <see cref="Texture"/>
		/// </summary>
		public SpriteSheet(Texture2D texture)
		{
			Texture = texture;
		}

		/// <summary>
		///		Creates a new <see cref="SpriteRegion"/> using the specified coordinates, width and height
		/// </summary>
		/// <returns></returns>
		public SpriteRegion CreateRegion(int x, int y, int width, int height) => CreateRegion(new Rectangle(x, y, width, height));

		/// <summary>
		///		Returns the <see cref="SpriteRegion"/> at the specified index
		/// </summary>
		public SpriteRegion GetRegionByIndex(int index)
		{
			Guard.Requires(index > 0 && index <= _regions.Count, () => new IndexOutOfRangeException());
			return _regions[index];
		}

		/// <summary>
		///		Creates a new <see cref="SpriteRegion"/> using the specified boundaries
		/// </summary>
		public SpriteRegion CreateRegion(Rectangle bounds)
		{
			var region = new SpriteRegion(Texture, bounds);
			_regions.Add(region);

			return region;
		}

		/// <summary>
		///		Returns all regions within this <see cref="SpriteSheet"/>
		/// </summary>
		public IEnumerable<SpriteRegion> Regions => _regions.AsReadOnly().AsEnumerable();

		/// <summary>
		///		Returns an enumerator that iterates through the collection.
		/// </summary>
		public IEnumerator<SpriteRegion> GetEnumerator() => _regions.GetEnumerator();

		/// <summary>
		///		Returns an enumerator that iterates through a collection.
		/// </summary>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		/// <summary>
		///		Creates a new <see cref="SpriteSheet"/> from the specified <see cref="Texture2D"/>, region width, region height
		///		and optional margin as well as spacing values
		/// </summary>
		public static SpriteSheet Create(Texture2D texture, int regionWidth, int regionHeight, int margin = 0, int spacing = 0)
		{
			var spriteSheet		= new SpriteSheet(texture);
			var width			= texture.Width - margin;
			var height			= texture.Height - margin;

			for (var y = margin; y < height; y += (regionHeight + spacing)) {
				for (var x = margin; x < width; x += (regionWidth + spacing)) {
					spriteSheet.CreateRegion(x, y, regionWidth, regionHeight);
				}
			}

			return spriteSheet;
		}

	}

}
