using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pressiah.Entities;

namespace Pressiah.Core
{

    /// <summary>
    ///     Extensions for <see cref="IComparable"/>
    /// </summary>
    public static class ComparableExtensions
    {

        /// <summary>
        ///     Returns whether the specified instance of <see cref="IComparable"/> is less than another specified instance of <see cref="IComparable"/>
        /// </summary>
        public static bool IsLessThan(this IComparable comparable, IComparable other) => comparable.CompareTo(other) < 0;

        /// <summary>
        ///     Returns whether the specified instance of <see cref="IComparable"/> is less than or equal to another specified instance of <see cref="IComparable"/>
        /// </summary>
        public static bool IsLessThanOrEqualTo(this IComparable comparable, IComparable other) => comparable.IsLessThan(other) || comparable.IsEqualTo(other);

        /// <summary>
        ///     Returns whether the specified instance of <see cref="IComparable"/> is greater than another specified instance of <see cref="IComparable"/>
        /// </summary>
        public static bool IsGreaterThan(this IComparable comparable, IComparable other) => comparable.CompareTo(other) > 0;

        /// <summary>
        ///     Returns whether the specified instance of <see cref="IComparable"/> is greater than or equal to another specified instance of <see cref="IComparable"/>
        /// </summary>
        public static bool IsGreaterThanOrEqualTo(this IComparable comparable, IComparable other) => comparable.IsGreaterThan(other) || comparable.IsEqualTo(other);

        /// <summary>
        ///     Returns whether the specified instance of <see cref="IComparable"/> is equal to another specified instance of <see cref="IComparable"/>
        /// </summary>
        public static bool IsEqualTo(this IComparable comparable, IComparable other) => comparable.CompareTo(other) == 0;

        /// <summary>
        ///     Returns whether the specified <see cref="IComparable"/> is between two ranges (inclusive)
        /// </summary>
        public static bool IsBetweenInclusive(this IComparable comparable, IComparable lower, IComparable upper)
             => comparable.IsGreaterThanOrEqualTo(lower) && comparable.IsLessThanOrEqualTo(upper);

        /// <summary>
        ///     Returns whether the specified <see cref="IComparable"/> is between two ranges (exclusive)
        /// </summary>
        public static bool IsBetweenExclusive(this IComparable comparable, IComparable lower,
            IComparable upper)
            => comparable.IsGreaterThan(lower) && comparable.IsLessThan(lower);
    }

}
