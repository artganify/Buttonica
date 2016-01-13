using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Buttonica.Core.Framework
{
	/// <summary>
	///		Represents an updateable type
	/// </summary>
	public interface IUpdateBehavior : IBehavior
	{

		/// <summary>
		///		Invokes the update call on the current instance, specifying the main <see cref="GameTime"/>
		/// </summary>
		void Update(GameTime gameTime);

	}
}
