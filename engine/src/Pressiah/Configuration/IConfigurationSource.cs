namespace Pressiah.Configuration
{
    /// <summary>
    ///     Represents a strongly typed configuration provider
    /// </summary>
    /// <typeparam name="TConfiguration">Arbitary reference type</typeparam>
    public interface IConfigurationSource<TConfiguration>
        where TConfiguration : class
    {

        /// <summary>
        ///     Loads the configuration graph from the underlying source
        /// </summary>
        TConfiguration GetConfiguration();

        /// <summary>
        ///     Stores the configuration graph to the underlying source
        /// </summary>
        void StoreConfiguration(TConfiguration configuration);

    }
}