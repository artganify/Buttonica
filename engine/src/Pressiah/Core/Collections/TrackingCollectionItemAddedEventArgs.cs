namespace Pressiah.Core.Collections
{
    /// <summary>
    ///     Event arguments used to indicate an addition to a <see cref="TrackingCollection{T}"/>
    /// </summary>
    public class TrackingCollectionItemAddedEventArgs<T> : TrackingCollectionChangedEventArgs<T>
    {

        /// <summary>
        ///     Returns the index of the item within the tracking collection
        /// </summary>
        public int Index { get; }

        /// <summary>
        ///     Creates a new <see cref="TrackingCollectionItemAddedEventArgs{T}"/>, specifying the index of the item and the item affected by the change
        /// </summary>
        public TrackingCollectionItemAddedEventArgs(int index, T item) 
            : base(item)
        {
            Index = index;
        }

    }
}