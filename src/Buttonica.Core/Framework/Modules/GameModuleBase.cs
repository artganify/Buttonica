using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buttonica.Core.Framework.Core;
using Microsoft.Xna.Framework;
using IUpdateable = Buttonica.Core.Framework.Core.IUpdateable;

namespace Buttonica.Core.Framework.Modules
{
	public class GameModuleBase : ComponentBase, IGameModule, IUpdateable, IRenderable
	{

		/// <summary>
		///		Invoked the update routine on the instance, specifying the current <see cref="GameTime"/>
		/// </summary>
		public virtual void Update(GameTime gameTime)
		{
			
		}

		/// <summary>
		///		Invokes the render routine on the instance, specifying the current <see cref="GameTime"/>
		/// </summary>
		public virtual void Render(GameTime gameTime)
		{

		}

	}
}
