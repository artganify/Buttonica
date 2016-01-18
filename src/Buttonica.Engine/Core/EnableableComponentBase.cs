namespace Buttonica.Engine.Core
{
	/// <summary>
	///     Represents a base component which supports being enabled / disabled
	/// </summary>
	public abstract class EnableableComponentBase : ComponentBase
	{
		private bool _isEnabled = true; // enabled by default

		/// <summary>
		///     Returns whether the component is currently enabled
		/// </summary>
		public bool IsEnabled
		{
			get { return _isEnabled; }
			set
			{
				if (value == _isEnabled)
					return;

				_isEnabled = value;

				if (value)
					OnEnabled();
				else
					OnDisabled();
			}
		}

		/// <summary>
		///     Invoked when the component has been enabled
		/// </summary>
		protected virtual void OnEnabled()
		{
		}

		/// <summary>
		///     Invoked when the component has been disabled
		/// </summary>
		protected virtual void OnDisabled()
		{
		}
	}
}