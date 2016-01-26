using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pressiah.Game
{

    // TODO disposable, async
    // - Is content always unmanaged stuff? Should we implement IDisposable then?
    // - Should content be loaded asynchronously, using TAP?

    /// <summary>
    ///     Represents a type which loads and unloads game resources, such as music, sfc, sprite graphics, etc.
    /// </summary>
    public interface IContentable
    {

        /// <summary>
        ///     Loads the content of the current instance
        /// </summary>
        void LoadContent();

        /// <summary>
        ///     Unloads the content of the current instance
        /// </summary>
        void UnloadContent();

    }
}
