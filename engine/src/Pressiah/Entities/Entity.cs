using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pressiah.Core;
using Pressiah.Entities.Components;

namespace Pressiah.Entities
{
    public class Entity : ComponentBase, IEntity
    {

        /// <summary>
        ///     Returns the identifier of the current instance
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        ///     Returns a sequence of <see cref="IEntityComponent"/> which are attached to this entity
        /// </summary>
        public IEnumerable<IEntityComponent> Components { get; }
    }
}
