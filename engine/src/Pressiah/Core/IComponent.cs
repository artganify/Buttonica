using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pressiah.Core
{

    /// <summary>
    ///     Common contract for all components of the engine
    /// </summary>
    public interface IComponent
    {

        /// <summary>
        ///     Returns the name of the component
        /// </summary>
        string Name { get; }

    }

}
