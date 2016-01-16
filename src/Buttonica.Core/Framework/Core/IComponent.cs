namespace Buttonica.Core.Framework.Core
{

	/// <summary>
	///		Common contract for all engine components
	/// </summary>
	public interface IComponent
	{

		/// <summary>
		///		Returns the name of the component
		/// </summary>
		string Name { get; }

	}

}
