using System;
using System.Linq;
using Buttonica.Engine.Core;
using Buttonica.Engine.Entities;
using Microsoft.Xna.Framework;
using IUpdateable = Buttonica.Engine.Core.IUpdateable;

namespace Buttonica.Engine.Scenes
{
	/// <summary>
	///     Represents an individual state of the game
	/// </summary>
	public class Scene : EntityContainer, IUpdateable, IRenderable
	{
		/// <summary>
		///     Returns whether the scene is currently active
		/// </summary>
		public bool IsActive { get; private set; }

		/// <summary>
		///     Returns whether the scene is currently paused
		/// </summary>
		public bool IsPaused { get; private set; }

		/// <summary>
		///     Invokes the render routine on the instance, specifying the current <see cref="GameTime" />
		/// </summary>
		public virtual void Render(GameTime gameTime)
		{
			if (!IsActive)
				return;

			OnRender(gameTime);
		}

		/// <summary>
		///     Invokes the update routine on the instance, specifying the current <see cref="GameTime" />
		/// </summary>
		public virtual void Update(GameTime gameTime)
		{
			if (!IsActive)
				return;

			OnUpdate(gameTime);
		}

		/// <summary>
		///     Activates the current scene
		/// </summary>
		public void Activate()
		{
			if (IsActive)
				return;

			IsPaused = false;
			IsActive = true;

			OnActivate();
		}

		/// <summary>
		///     Pauses the current scene
		/// </summary>
		public void Pause()
		{
			if (!IsActive || IsPaused)
				return;

			OnPause();
			IsPaused = true;
		}

		/// <summary>
		///     Resumes the current scene
		/// </summary>
		public void Resume()
		{
			if (!IsActive || !IsPaused)
				return;

			IsPaused = false;
		}

		/// <summary>
		///     Deactivates the current scene
		/// </summary>
		public void Deactivate()
		{
			if (!IsActive)
				return;

			IsPaused = false;
			IsActive = false;

			// disable all disableable entities
			foreach (var disableableEntity in Entities.OfType<EnableableComponentBase>())
				disableableEntity.IsEnabled = false;

			OnDeactivate();
		}


		/// <summary>
		///     Invoked during disposal of managed resources
		/// </summary>
		protected override void OnManagedDisposal()
		{
			Deactivate();

			// dispose all disposable entities
			foreach (var disposableEntity in Entities.OfType<IDisposable>())
				disposableEntity.Dispose();

			base.OnManagedDisposal();
		}


		/// <summary>
		///     Invoked when the scene is being activated
		/// </summary>
		protected virtual void OnActivate()
		{
		}

		/// <summary>
		///     Invoked when the scene is being paused
		/// </summary>
		protected virtual void OnPause()
		{
		}

		/// <summary>
		///     Invoked when the scene is being resumed
		/// </summary>
		protected virtual void OnResume()
		{
		}

		/// <summary>
		///     Invoked when the scene is being deactivated
		/// </summary>
		protected virtual void OnDeactivate()
		{
		}

		/// <summary>
		///     Invoked during update of the scene
		/// </summary>
		protected virtual void OnUpdate(GameTime gameTime)
		{
		}

		/// <summary>
		///     Invoked during rendering of the scene
		/// </summary>
		protected virtual void OnRender(GameTime gameTime)
		{
		}
	}
}