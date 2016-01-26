using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization.ObjectFactories;

namespace Pressiah.Configuration
{
    /// <summary>
    ///     Provides an implementation of <see cref="IConfigurationSource{TConfiguration}" /> based on YAML-syntax files
    /// </summary>
    /// <typeparam name="TConfiguration">Arbitary reference type with empty .ctor</typeparam>
    public class YamlFileConfigurationSource<TConfiguration> : IConfigurationSource<TConfiguration>
        where TConfiguration : class, new()
    {
        private readonly bool _createIfNotExists;

        private readonly Deserializer _deserializer = new Deserializer(new DefaultObjectFactory(),
            new HyphenatedNamingConvention(), true);

        // YAML stuff
        private readonly Serializer _serializer = new Serializer(SerializationOptions.EmitDefaults,
            new HyphenatedNamingConvention());

        /// <summary>
        ///     Returns the path to the current configuration file
        /// </summary>
        public string Path { get; }

        /// <summary>
        ///     Returns whether the current configuration file exists
        /// </summary>
        public bool Exists => File.Exists(Path);


        /// <summary>
        ///     Creates a new <see cref="YamlFileConfigurationSource{TConfiguration}" /> specifying the path to the configuration
        ///     file
        ///     and optionally whether the configuration file should be created if it doesn't exist
        /// </summary>
        public YamlFileConfigurationSource(string path, bool createIfNotExists = true)
        {
            _guard.AgainstNullArgument(nameof(path), path);
            Path = path;
            _createIfNotExists = createIfNotExists;

            if (!Exists && _createIfNotExists)
                InitializeWithDefaults();
        }

        /// <summary>
        ///     Loads the configuration graph from the underlying source
        /// </summary>
        public TConfiguration GetConfiguration()
        {
            if (!Exists && _createIfNotExists)
                return InitializeWithDefaults();

            try
            {
                using (var stream = File.Open(Path, _createIfNotExists ? FileMode.OpenOrCreate : FileMode.Open, FileAccess.Read))
                using (var reader = new StreamReader(stream))
                    return _deserializer.Deserialize<TConfiguration>(reader);
            }
            catch
            {
                // always return defaults
                return new TConfiguration();
            }
        }

        /// <summary>
        ///     Stores the configuration graph into the underlying source
        /// </summary>
        public void StoreConfiguration(TConfiguration configuration)
        {
            using (var stream = File.Open(Path, FileMode.Create, FileAccess.Write))
            using (var writer = new StreamWriter(stream))
                _serializer.Serialize(writer, configuration ?? new TConfiguration());
        }

        private TConfiguration InitializeWithDefaults()
        {
            var configuration = new TConfiguration();
            StoreConfiguration(configuration);

            return configuration;
        }
    }
}