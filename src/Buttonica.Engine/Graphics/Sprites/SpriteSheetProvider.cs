using System.Linq;
using Buttonica.Engine.Core;

namespace Buttonica.Engine.Graphics.Sprites
{
	/// <summary>
	///     Represents a <see cref="ISpriteProvider" /> which retrieves sprites from a <see cref="SpriteSheet" />
	/// </summary>
	public class SpriteSheetProvider : ComponentBase, ISpriteProvider
	{
		/// <summary>
		///     Returns the underlying <see cref="Sprites.SpriteSheet" />
		/// </summary>
		public SpriteSheet SpriteSheet { get; }

		/// <summary>
		///     Creates a new <see cref="SpriteSheetProvider" /> specifying it's underlying <see cref="Sprites.SpriteSheet" />
		/// </summary>
		public SpriteSheetProvider(SpriteSheet spriteSheet)
		{
			Guard.AgainstNullArgument(nameof(spriteSheet), spriteSheet);
			SpriteSheet = spriteSheet;
		}

		/// <summary>
		///     Retrieves a sprite by the specified index
		/// </summary>
		public Sprite GetSpriteByIndex(int index)
		{
			if (SpriteSheet?.Sprites == null || !SpriteSheet.Any())
				return null;

			return SpriteSheet.GetSpriteByIndex(index);
		}
	}
}