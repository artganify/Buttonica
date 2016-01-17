namespace Buttonica.Engine.Framework.Rendering2D.Sprites
{
	/// <summary>
	///     Represents a provider for retrieving <see cref="Sprite">sprites</see>
	/// </summary>
	public interface ISpriteProvider
	{
		/// <summary>
		///     Retrieves a sprite by the specified index
		/// </summary>
		Sprite GetSpriteByIndex(int index);
	}
}