using Buttonica.Engine.Framework.Core;
using Microsoft.Xna.Framework;
using IUpdateable = Buttonica.Engine.Framework.Core.IUpdateable;

namespace Buttonica.Engine.Framework.Modules
{
	/// <summary>
	///     Provides a base implementation of a <see cref="IGameModule" />
	/// </summary>
	public abstract class GameModuleBase : ComponentBase, IGameModule, IUpdateable
	{
		/// <summary>
		///     Invokes the update routine on the instance, specifying the current <see cref="GameTime" />
		/// </summary>
		public virtual void Update(GameTime gameTime)
		{
		}
	}
}