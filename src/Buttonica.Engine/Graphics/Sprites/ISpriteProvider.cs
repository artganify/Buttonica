using Buttonica.Engine.Core;

namespace Buttonica.Engine.Graphics.Sprites
{
	/// <summary>
	///     Represents a provider for retrieving <see cref="Sprite">sprites</see>
	/// </summary>
	public interface ISpriteProvider : IComponent
	{
		/// <summary>
		///     Retrieves a sprite by the specified index
		/// </summary>
		Sprite GetSpriteByIndex(int index);
	}
}