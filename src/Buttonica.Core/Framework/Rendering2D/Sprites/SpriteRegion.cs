﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Buttonica.Core.Framework.Rendering2D.Sprites
{

	/// <summary>
	///		Represents an individual region of a <see cref="SpriteSheet"/>
	/// </summary>
	public class SpriteRegion
	{

		/// <summary>
		///		Returns the region texture
		/// </summary>
		public Texture2D Texture { get; }

		/// <summary>
		///		Returns the boundaries of the region
		/// </summary>
		public Rectangle Bounds { get; }

		/// <summary>
		///		Returns the width of the region
		/// </summary>
		public int Width => Bounds.Width;

		/// <summary>
		///		Returns the height of the region
		/// </summary>
		public int Height => Bounds.Height;

		/// <summary>
		///		Returns the X coordinate of the region
		/// </summary>
		public int X => Bounds.X;

		/// <summary>
		///		Returns the Y coordinate of the region
		/// </summary>
		public int Y => Bounds.Y;

		/// <summary>
		///		Creates a new <see cref="SpriteRegion"/> using the specified <see cref="Texture2D"/> and dimensions
		/// </summary>
		public SpriteRegion(Texture2D texture, int x, int y, int width, int height)
			: this(texture, new Rectangle(x, y, width, height))
		{
			
		}

		/// <summary>
		///		Creates a new <see cref="SpriteRegion"/> using the specified <see cref="Texture2D"/> and 
		///		<see cref="Rectangle">bounds</see>
		/// </summary>
		public SpriteRegion(Texture2D texture, Rectangle bounds)
		{
			Bounds	= bounds;
			Texture = texture;
		}

		/// <summary>
		///		Creates a new <see cref="SpriteRegion"/> using the specified <see cref="Texture2D"/>
		/// </summary>
		public SpriteRegion(Texture2D texture)
			: this(texture, 0, 0, texture.Width, texture.Height)
		{
			
		}

	}
}
