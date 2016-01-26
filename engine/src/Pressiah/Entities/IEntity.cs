using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pressiah.Core;
using Pressiah.Entities.Components;

namespace Pressiah.Entities
{

    /// <summary>
    ///     Represents the contract for an individual entity within the world space
    /// </summary>
    public interface IEntity : IComponent, IIdentifiable
    {

        /// <summary>
        ///     Returns a sequence of <see cref="IEntityComponent"/> which are attached to this entity
        /// </summary>
        IEnumerable<IEntityComponent> Components { get; } 

    }

}
