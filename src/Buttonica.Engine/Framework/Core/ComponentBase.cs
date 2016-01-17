namespace Buttonica.Engine.Framework.Core
{
	/// <summary>
	///     Provides a base implementation for <see cref="IComponent" />
	/// </summary>
	public abstract class ComponentBase : DisposableBase, IComponent
	{
		private string _name;

		/// <summary>
		///     Creates a <see cref="ComponentBase" />, optionally specifying it's name
		/// </summary>
		/// <remarks>
		///     If no name is specified, the name of the current type will be used instead
		/// </remarks>
		protected ComponentBase(string name = null)
		{
			_name = name ?? GetType().Name;
		}

		/// <summary>
		///     Gets or sets the name of the component
		/// </summary>
		public string Name
		{
			get { return _name; }
			set
			{
				if (value == _name)
					return;

				_name = value ?? GetType().Name;

				OnComponentNameChanged();
			}
		}

		/// <summary>
		///     Invoked when the name of the component has changed
		/// </summary>
		protected virtual void OnComponentNameChanged()
		{
		}
	}
}