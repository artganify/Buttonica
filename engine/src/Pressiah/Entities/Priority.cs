using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pressiah.Entities
{

    /// <summary>
    ///     Specifies a priority value, ranging from <see cref="Highest"/> to <see cref="Lowest"/>
    /// </summary>
    public enum Priority
    {
        /// <summary>
        ///     Specifies the highest priority (<see cref="int.MinValue"/>)
        /// </summary>
        Highest = int.MinValue, 

        /// <summary>
        ///     Specifies a high priority (-100)
        /// </summary>
        High    = -100,

        /// <summary>
        ///     Specifies the default priority (0)
        /// </summary>
        Default = 0,

        /// <summary>
        ///     Specifies a low priority (100)
        /// </summary>
        Low     = 100,

        /// <summary>
        ///     Specifies the lowest (<see cref="int.MaxValue"/>)
        /// </summary>
        Lowest  = int.MaxValue
    }

}
