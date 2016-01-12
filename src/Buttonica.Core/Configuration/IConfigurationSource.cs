using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buttonica.Core.Configuration
{

	/// <summary>
	///		Represents a graph-based configuration source
	/// </summary>
	/// <typeparam name="TConfiguration">Arbitary reference type</typeparam>
	public interface IConfigurationSource<TConfiguration>
		where TConfiguration : class
	{

		/// <summary>
		///		Loads the configuration graph from the underlying source
		/// </summary>
		TConfiguration GetConfiguration();

		/// <summary>
		///		Stores the configuration graph into the underlying source
		/// </summary>
		void StoreConfiguration(TConfiguration configuration);

	}

}
