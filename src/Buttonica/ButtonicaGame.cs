using Buttonica.Engine.Framework.Scenes;
using Microsoft.Xna.Framework;

namespace Buttonica
{
	public class ButtonicaGame : Game
	{
		private readonly GraphicsDeviceManager _graphics;

		private readonly ISceneModule _sceneModule;

		public ButtonicaGame()
		{
			Window.Title = "Buttonica: Realms Of Color";
			Content.RootDirectory = "Content";

			_graphics = new GraphicsDeviceManager(this);
		}

		protected override void Initialize()
		{
			base.Initialize();
		}

		protected override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			base.Draw(gameTime);
		}
	}
}