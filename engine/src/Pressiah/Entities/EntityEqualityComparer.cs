using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pressiah.Entities
{

    /// <summary>
    ///     Provides a default implementation of a <see cref="IEntityEqualityComparer"/> which compares the equality
    ///     of entities based on their unique identifier (<see cref="IIdentifiable.Id"/>)
    /// </summary>
    public class EntityEqualityComparer : IEntityEqualityComparer
    {

        /// <summary>
        ///     Returns a default instance of the <see cref="EntityEqualityComparer"/>
        /// </summary>
        public static readonly EntityEqualityComparer Default = new EntityEqualityComparer();

        /// <summary>
        ///     Determines whether the specified instances of <see cref="IEntity"/> are equal
        /// </summary>
        public bool Equals(IEntity x, IEntity y)
        {
            // we asume that if one of the entities is null, and thus doesn't have an identity,
            // then it can never be equal to another entity which has an identity
            if (x == null || y == null)
                return false;

            return x.Id.Equals(y.Id);
        }

        /// <summary>
        ///     Returns a hash code for the specified object.
        /// </summary>
        public int GetHashCode(IEntity obj)
        {
            _guard.AgainstNullArgument(nameof(obj), obj);
            return obj.Id.GetHashCode();
        }

    }
}
