namespace Buttonica.Engine.Framework.Core
{
	/// <summary>
	///     Represents a type which contains content resources, such as textures, music, sprites...
	/// </summary>
	public interface IContentable
	{
		/// <summary>
		///     Returns whether the content of the instance has been loaded
		/// </summary>
		bool IsLoaded { get; }

		/// <summary>
		///     Instructs the instance to load it's content
		/// </summary>
		void LoadContent();

		/// <summary>
		///     Instructs the instance to unload it's content
		/// </summary>
		void UnloadContent();
	}
}