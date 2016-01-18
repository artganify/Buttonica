using System;
using Buttonica.Engine.Core;
using Buttonica.Engine.Modules;

namespace Buttonica.Engine.Scenes
{

	/// <summary>
	///     Represents a game module which manages the individual states of the game in a LIFO collection
	/// </summary>
	public interface ISceneModule : IGameModule, IUpdateable, IRenderable, IDisposable
	{

		/// <summary>
		///     Pushes the specified <see cref="Scene" /> on top of the collection, specifying whether the scene is modal
		/// </summary>
		void Push(Scene scene, bool isModal);

		/// <summary>
		///     Exits the currently active scene and reactivates any underlying ones
		/// </summary>
		void Pop();

	}

}