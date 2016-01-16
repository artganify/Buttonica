using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Buttonica.Core.Framework
{

	/// <summary>
	///		Represents a type which supports update calls
	/// </summary>
	public interface IUpdateable
	{

		/// <summary>
		///		Invokes the update routine on the instance, specifying the current <see cref="GameTime"/>
		/// </summary>
		void Update(GameTime gameTime);

	}

}
