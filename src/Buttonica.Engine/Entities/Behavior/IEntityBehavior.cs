using System.Security.Cryptography.X509Certificates;
using Buttonica.Engine.Core;

namespace Buttonica.Engine.Entities.Behavior
{

	/// <summary>
	///		Common contract for entity behaviors
	/// </summary>
	public interface IEntityBehavior : IComponent
	{

		/// <summary>
		///		Returns whether the behavior is currently enabled
		/// </summary>
		bool IsEnabled { get; }

	}

}
