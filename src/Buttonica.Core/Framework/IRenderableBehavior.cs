using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Buttonica.Core.Framework
{

	/// <summary>
	///		Represents a renderable type
	/// </summary>
	public interface IRenderableBehavior : IBehavior
	{

		/// <summary>
		///		Invokes the render call on the current instance, specifying the main <see cref="GameTime"/>
		/// </summary>
		void Render(GameTime gameTime);

	}

}
