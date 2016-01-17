using System;
using System.Collections;
using System.Collections.Generic;
using Buttonica.Engine.Framework.Core;
using Microsoft.Xna.Framework;
using IUpdateable = Buttonica.Engine.Framework.Core.IUpdateable;

namespace Buttonica.Engine.Framework.Modules
{
	/// <summary>
	///     Represents a collection of game modules
	/// </summary>
	public class GameModuleSystem : GameModuleBase, IRenderable, IEnumerable<IGameModule>
	{
		private readonly List<IRenderable> _currentlyRenderingModules = new List<IRenderable>();
		private readonly List<IUpdateable> _currentlyUpdatingModules = new List<IUpdateable>();

		private readonly List<IGameModule> _registeredModules = new List<IGameModule>();
		private readonly List<IRenderable> _renderableModules = new List<IRenderable>();
		private readonly List<IUpdateable> _updateableModules = new List<IUpdateable>();

		/// <summary>
		///     Returns an enumerator that iterates through the collection.
		/// </summary>
		public IEnumerator<IGameModule> GetEnumerator() => _registeredModules.GetEnumerator();

		/// <summary>
		///     Returns an enumerator that iterates through a collection.
		/// </summary>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		/// <summary>
		///     Invokes the render routine on the instance, specifying the current <see cref="GameTime" />
		/// </summary>
		public void Render(GameTime gameTime)
		{
			lock (_renderableModules)
				_currentlyRenderingModules.AddRange(_renderableModules);

			_currentlyRenderingModules.ForEach(renderable => renderable.Render(gameTime));
			_currentlyRenderingModules.Clear();
		}

		/// <summary>
		///     Registers the specified <see cref="IGameModule" /> within the system
		/// </summary>
		public void RegisterModule(IGameModule gameModule)
		{
			Guard.AgainstNullArgument(nameof(gameModule), gameModule);

			lock (_renderableModules)
				ApplyCategorizedOnCollection(gameModule, _renderableModules, (list, renderable)
					=> list.Add(renderable));

			lock (_updateableModules)
				ApplyCategorizedOnCollection(gameModule, _updateableModules, (list, updateable)
					=> list.Add(updateable));

			lock (_registeredModules)
				ApplyCategorizedOnCollection(gameModule, _registeredModules, (list, module)
					=> list.Add(module));
		}

		/// <summary>
		///     Removes the specified <see cref="IGameModule" /> from the system
		/// </summary>
		public void RemoveModule(IGameModule gameModule)
		{
			Guard.AgainstNullArgument(nameof(gameModule), gameModule);

			lock (_renderableModules)
				ApplyCategorizedOnCollection(gameModule, _renderableModules, (list, renderable)
					=> list.Remove(renderable));

			lock (_updateableModules)
				ApplyCategorizedOnCollection(gameModule, _updateableModules, (list, updateable)
					=> list.Remove(updateable));

			lock (_registeredModules)
				ApplyCategorizedOnCollection(gameModule, _registeredModules, (list, module)
					=> list.Remove(module));
		}

		/// <summary>
		///     Invokes the update routine on the instance, specifying the current <see cref="GameTime" />
		/// </summary>
		public override void Update(GameTime gameTime)
		{
			lock (_updateableModules)
				_currentlyUpdatingModules.AddRange(_updateableModules);

			_currentlyUpdatingModules.ForEach(updateable => updateable.Update(gameTime));
			_currentlyUpdatingModules.Clear();
		}

		private static void ApplyCategorizedOnCollection<TCategory>(IGameModule gameModule, List<TCategory> collection,
			Action<List<TCategory>, TCategory> collectionAction)
			where TCategory : class
		{
			var categorized = gameModule as TCategory;
			if (categorized == null)
				return;

			collectionAction.Invoke(collection, categorized);
		}
	}
}