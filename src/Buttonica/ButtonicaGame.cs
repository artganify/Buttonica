using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buttonica.Core.Framework;
using Buttonica.Core.Framework.Core;
using Buttonica.Core.Framework.Modules;
using Buttonica.Core.Framework.Scenes;
using Microsoft.Xna.Framework;
using IUpdateable = Buttonica.Core.Framework.Core.IUpdateable;

namespace Buttonica
{
	public class ButtonicaGame : Game
	{


		private readonly List<IGameModule>		_gameModules	= new List<IGameModule>();

		private readonly ISceneStack			_sceneStack;
		private readonly GraphicsDeviceManager	_graphics;

		public ButtonicaGame()
		{
			Window.Title			= "Buttonica: Realms Of Color";
			Content.RootDirectory	= "Content";
			
			_graphics				= new GraphicsDeviceManager(this);
			_sceneStack				= new SceneStack();
		}

		protected override void Initialize()
		{
			base.Initialize();

			_gameModules.Add(new SceneStack());
		}

		protected override void LoadContent()
		{
			base.LoadContent();
		}

		protected override void Update(GameTime gameTime)
		{
			base.Update(gameTime);

			foreach (var updateableModule in _gameModules.Where(module => module is IUpdateable).Cast<IUpdateable>()) {
				updateableModule.Update(gameTime);
			}
		}

		protected override void Draw(GameTime gameTime)
		{
			base.Draw(gameTime);

			foreach (var renderableModule in _gameModules.Where(module => module is IRenderable).Cast<IRenderable>()) {
				renderableModule.Render(gameTime);
			}
		}

	}

}
