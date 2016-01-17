using System;
using Buttonica.Engine.Framework.Core;
using Buttonica.Engine.Framework.Modules;

namespace Buttonica.Engine.Framework.Scenes
{
	/// <summary>
	///     Represents a game module which manages the individual states of the game in a LIFO collection
	/// </summary>
	public interface ISceneModule : IGameModule, IUpdateable, IRenderable, IDisposable
	{
		/// <summary>
		///     Returns the currently active scene
		/// </summary>
		Scene ActiveScene { get; }

		/// <summary>
		///     Pushes the specified <see cref="Scene" /> on top of the stack, specifying whether the scene is modal
		/// </summary>
		void Push(Scene scene, bool isModal);

		/// <summary>
		///     Exits the currently active scene and reactivates any underlying ones
		/// </summary>
		void Pop();
	}
}