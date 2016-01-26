using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pressiah.Entities
{

    /// <summary>
    ///     Represents a uniquely identifiable type
    /// </summary>
    public interface IIdentifiable
    {

        /// <summary>
        ///     Returns the identifier of the current instance
        /// </summary>
        Guid Id { get; }

    }
}
