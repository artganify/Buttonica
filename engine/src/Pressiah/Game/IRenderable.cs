using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pressiah.Game
{
    /// <summary>
    ///     Represents a type which supports rendering calls
    /// </summary>
    public interface IRenderable
    {

        /// <summary>
        ///     Invokes the render procedure of the instance, providing the current <see cref="GameTime"/>
        /// </summary>
        void Render(GameTime gameTime);

    }
}
