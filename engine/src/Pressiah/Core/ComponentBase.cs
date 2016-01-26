using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pressiah.Core
{

    /// <summary>
    ///     Provides a base implementation of a <see cref="IComponent"/>
    /// </summary>
    public abstract class ComponentBase : IComponent
    {

        private string _name;

        /// <summary>
        ///     Gets or sets the name of the component
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if(value == _name)
                    return;

                _name = value ?? GetType().Name;
                OnNameChanged();
            }
        }

        /// <summary>
        ///     Creates a new <see cref="ComponentBase"/>
        /// </summary>
        protected ComponentBase()
            : this(null)
        {
            
        }

        /// <summary>
        ///     Creates a new <see cref="ComponentBase"/>, specifying it's name
        /// </summary>
        /// <remarks>
        ///     If the provided <paramref name="name"/> is null, the default name of the type will be used
        /// </remarks>
        protected ComponentBase(string name)
        {
            _name = name ?? GetType().Name;
        }

        /// <summary>
        ///     Invoked when the name of the component has changed
        /// </summary>
        protected virtual void OnNameChanged()
        {
            
        }

    }
}
