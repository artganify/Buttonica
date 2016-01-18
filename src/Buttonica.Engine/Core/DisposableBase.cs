using System;

namespace Buttonica.Engine.Core
{
	/// <summary>
	///     Provides a simple base implementation of <see cref="IDisposable" /> which automatically
	///     invoked calls to free either managed or unmanaged resources
	/// </summary>
	public abstract class DisposableBase : IDisposable
	{
		/// <summary>
		///     Returns whether the instance has been disposed
		/// </summary>
		public bool IsDisposed { get; private set; }

		/// <summary>
		///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			if (IsDisposed)
				return;

			GC.SuppressFinalize(this);

			// invoke freeing managed / unmanaged resources
			OnManagedDisposal();
			OnUnmanagedDisposal();

			IsDisposed = true;
		}

		/// <summary>
		///     Finalizes the instance
		/// </summary>
		// TODO .NET seems to treat types with finalizers differently. Investigate.
		~DisposableBase()
		{
			OnUnmanagedDisposal();
		}

		/// <summary>
		///     Invoked during disposal of managed resources
		/// </summary>
		protected virtual void OnManagedDisposal()
		{
		}

		/// <summary>
		///     Invoked during disposal of unmanaged resources
		/// </summary>
		protected virtual void OnUnmanagedDisposal()
		{
		}
	}
}