using Microsoft.Xna.Framework;

namespace Buttonica.Engine.Framework.Modules
{
	/// <summary>
	///     Represents a base implementation of a graphical module
	/// </summary>
	public abstract class GraphicalModuleBase : GameModuleBase
	{
		/// <summary>
		///     Invokes the render routine on the instance, specifying the current <see cref="GameTime" />
		/// </summary>
		public virtual void Render(GameTime gameTime)
		{
		}
	}
}