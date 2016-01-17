using Microsoft.Xna.Framework;

namespace Buttonica.Platform.Desktop
{
	internal class Application
	{
		private static void Main(string[] args)
		{

			using (var game = new ButtonicaGame())
				game.Run(GameRunBehavior.Synchronous);

		}
	}
}