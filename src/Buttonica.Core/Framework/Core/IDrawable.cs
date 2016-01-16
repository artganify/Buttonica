using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Buttonica.Core.Framework
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
