using System;
using System.Collections;
using System.Collections.Generic;
using Buttonica.Engine.Core;
using Microsoft.Xna.Framework;
using IUpdateable = Buttonica.Engine.Core.IUpdateable;

namespace Buttonica.Engine.Modules
{
	/// <summary>
	///     Represents a collection of game modules
	/// </summary>
	public class GameModuleSystem : GameModuleBase, IRenderable, IEnumerable<IGameModule>
	{

		/// <summary>
		///     Invokes the render routine on the instance, specifying the current <see cref="GameTime" />
		/// </summary>
		public void Render(GameTime gameTime)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>
		/// An enumerator that can be used to iterate through the collection.
		/// </returns>
		public IEnumerator<IGameModule> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
		/// </returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

	}
}