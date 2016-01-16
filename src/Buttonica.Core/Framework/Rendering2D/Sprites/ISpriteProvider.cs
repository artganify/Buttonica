using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buttonica.Core.Framework.Rendering2D.Sprites
{

	/// <summary>
	///		Represents a provider for retrieving <see cref="Sprite">sprites</see>
	/// </summary>
	public interface ISpriteProvider
	{

		/// <summary>
		///		Retrieves a sprite by the specified index
		/// </summary>
		Sprite GetSpriteByIndex(int index);

	}
}
