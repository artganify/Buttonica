using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pressiah.Entities
{

    /// <summary>
    ///     Represents the contract for entity equality comparers
    /// </summary>
    public interface IEntityEqualityComparer : IEqualityComparer<IEntity>
    {

    }

}
