using Buttonica.Engine.Modules;
using Buttonica.Engine.Scenes;
using Microsoft.Xna.Framework;

namespace Buttonica
{
	public class ButtonicaGame : Game
	{
		// modules
		private readonly GameModuleSystem _gameModules = new GameModuleSystem();
		private readonly GraphicsDeviceManager _graphics;
		private readonly ISceneModule _sceneModule = new SceneModule();


		public ButtonicaGame()
		{
			Window.Title = "Buttonica: Realms Of Color";
			Content.RootDirectory = "Content";

			_graphics = new GraphicsDeviceManager(this);
		}

		protected override void Initialize()
		{
			// TODO do we need to call initialize here?
			//base.Initialize();

			_gameModules.RegisterModule(_sceneModule);
		}

		protected override void Update(GameTime gameTime)
		{
			// update game modules
			_gameModules.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			_graphics.GraphicsDevice.Clear(Color.Pink); // fabulous!

			// render game modules
			_gameModules.Render(gameTime);
		}
	}
}