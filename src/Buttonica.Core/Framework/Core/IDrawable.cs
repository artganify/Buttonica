using Microsoft.Xna.Framework;

namespace Buttonica.Core.Framework.Core
{
	/// <summary>
	///		Represents a type which supports render calls
	/// </summary>
	public interface IRenderable
	{

		/// <summary>
		///		Invokes the render routine on the instance, specifying the current <see cref="GameTime"/>
		/// </summary>
		void Render(GameTime gameTime);

	}

}
