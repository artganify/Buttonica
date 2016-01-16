using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buttonica.Core.Framework.Entities;
using Microsoft.Xna.Framework;

namespace Buttonica.Core.Framework.Rendering2D.Sprites
{
	public sealed class SpriteComponent : ActivatableEntityComponentBase
	{

		/// <summary>
		///		Gets ort sets the color to apply on the sprite
		/// </summary>
		public Color Color { get; set; } = Color.White;

		/// <summary>
		///		Gets or sets the <see cref="ISpriteProvider"/> for this component
		/// </summary>
		public ISpriteProvider SpriteProvider { get; set; }

		// return the sprite at 0 index for now, we can later use this for animation
		public Sprite Sprite => SpriteProvider.GetSpriteByIndex(0); 

		/// <summary>
		///		Creates a new <see cref="SpriteComponent"/> specifying it's owner
		/// </summary>
		public SpriteComponent(Entity2D owner) 
			: base(owner)
		{
			SpriteProvider = new SpriteSheetProvider();
		}

	}

}
