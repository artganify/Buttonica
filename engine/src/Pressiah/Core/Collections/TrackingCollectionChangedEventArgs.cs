using System;

namespace Pressiah.Core.Collections
{
    /// <summary>
    ///     Event arguments used to indicate a change within a <see cref="TrackingCollection{T}"/>
    /// </summary>
    public class TrackingCollectionChangedEventArgs<T> : EventArgs
    {

        /// <summary>
        ///     Returns the item affected by the change
        /// </summary>
        public T Item { get; }

        /// <summary>
        ///     Creates a new <see cref="TrackingCollectionChangedEventArgs{T}"/>, specifying the item affected by the change
        /// </summary>
        public TrackingCollectionChangedEventArgs(T item)
        {
            Item    = item;
        } 

    }
}