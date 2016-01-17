namespace Buttonica.Engine.Framework.Core
{
	/// <summary>
	///     Represents the common contract for all components of the engine
	/// </summary>
	public interface IComponent
	{
		/// <summary>
		///     Returns the name of the component
		/// </summary>
		string Name { get; }
	}
}