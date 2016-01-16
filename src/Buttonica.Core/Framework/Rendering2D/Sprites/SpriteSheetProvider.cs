using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buttonica.Core.Framework.Rendering2D.Sprites
{

	/// <summary>
	///		Represents a <see cref="ISpriteProvider"/> which retrieves sprites from a <see cref="SpriteSheet"/>
	/// </summary>
	public class SpriteSheetProvider : ISpriteProvider
	{

		/// <summary>
		///		Gets or sets the <see cref="SpriteSheet"/>
		/// </summary>
		public SpriteSheet SpriteSheet { get; set; }

		/// <summary>
		///		Retrieves a sprite by the specified index
		/// </summary>
		public Sprite GetSpriteByIndex(int index)
		{
			if (SpriteSheet?.Sprites == null || !SpriteSheet.Any())
				return null;

			return SpriteSheet.GetSpriteByIndex(index);
		}

	}
}
