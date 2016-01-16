using System;

namespace Buttonica.Core.Framework.Core
{

	/// <summary>
	///		Provides a base implementation for <see cref="IDisposable"/>
	/// </summary>
	public abstract class DisposableBase : IDisposable
	{

		/// <summary>
		///		Returns whether the instance has been disposed
		/// </summary>
		public bool IsDisposed { get; private set; }

		/// <summary>
		///		Finalizer
		/// </summary>
		~DisposableBase()
		{
			OnUnmanagedDisposal();
		}

		/// <summary>
		///		Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			if(IsDisposed)
				return;

			GC.SuppressFinalize(this);

			// invoke freeing managed / unmanaged resources
			OnManagedDisposal();
			OnUnmanagedDisposal();

			IsDisposed = true;
		}

		/// <summary>
		///		Invoked during disposal of managed resources
		/// </summary>
		protected virtual void OnManagedDisposal()
		{
			
		}

		/// <summary>
		///		Invoked during disposal of unmanaged resources
		/// </summary>
		protected virtual void OnUnmanagedDisposal()
		{
			
		}

	}
}
