using System.Collections.Generic;
using System.Linq;
using Buttonica.Engine.Framework.Modules;
using Microsoft.Xna.Framework;

namespace Buttonica.Engine.Framework.Scenes
{
	/// <summary>
	///     Represents the default scene stack module
	/// </summary>
	public class SceneModule : GameModuleBase, ISceneModule
	{
		private readonly Stack<Scene> _scenes = new Stack<Scene>();

		/// <summary>
		///     Returns the currently active scene
		/// </summary>
		public Scene ActiveScene => _scenes.Peek();

		/// <summary>
		///     Pushes the specified <see cref="Scene" /> on top of the stack, specifying
		///     whether the scene is modal
		/// </summary>
		public void Push(Scene scene, bool isModal)
		{
			Guard.AgainstNullArgument(nameof(scene), scene);

			if (_scenes.Any())
			{
				if (!isModal)
				{
					while (_scenes.Any())
						Pop();
				}
				else
				{
					// pause the currently active scene
					ActiveScene.Pause();
				}
			}

			_scenes.Push(scene);
			scene.Activate();
		}

		/// <summary>
		///     Exits the currently active scene and reactivates any underlying ones
		/// </summary>
		public void Pop()
		{
			if (!_scenes.Any())
				return;

			var lastScene = _scenes.Pop();
			lastScene.Dispose();

			if (_scenes.Any())
				// resume the underlying scene
				ActiveScene.Resume();
		}

		/// <summary>
		///     Invokes the render routine on the instance, specifying the current <see cref="GameTime" />
		/// </summary>
		public void Render(GameTime gameTime)
		{
			foreach (var scene in _scenes)
				scene.Update(gameTime);
		}

		/// <summary>
		///     Invoked the update routine on the instance, specifying the current <see cref="GameTime" />
		/// </summary>
		public override void Update(GameTime gameTime)
		{
			foreach (var scene in _scenes)
				scene.Render(gameTime);
		}

		/// <summary>
		///     Invoked during disposal of managed resources
		/// </summary>
		protected override void OnManagedDisposal()
		{
			base.OnManagedDisposal();

			while (_scenes.Count > 0)
				Pop();
		}
	}
}