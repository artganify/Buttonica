using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buttonica.Core.Framework
{

	/// <summary>
	///		Base implementation for components
	/// </summary>
	public abstract class ComponentBase : DisposableBase, IComponent
	{

		private string _name;

		/// <summary>
		///		Gets or sets the name of the component
		/// </summary>
		public string Name {
			get { return _name; }
			set {
				if(value == _name)
					return;

				var newName = value ?? GetType().Name;

				OnComponentNameChanging(newName);
				_name = newName;
			}
		}

		/// <summary>
		///		Creates a <see cref="ComponentBase"/>, optionally specifying it's name
		/// </summary>
		/// <remarks>
		///		If no name is specified, the name of the current type will be used instead
		/// </remarks>
		protected ComponentBase(string name = null)
		{
			_name = name ?? GetType().Name;
		}

		/// <summary>
		///		Invoked when the name of the component changes, specifying the newly assinged name
		/// </summary>
		protected virtual void OnComponentNameChanging(string newName)
		{
			
		}

	}
}
