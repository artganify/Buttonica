using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buttonica.Core.Diagnostics
{
	/// <summary>
	///     Provides lightweight guarding clauses for invocation arguments
	/// </summary>
	public static class Guard
	{
		/// <summary>
		///     Guards against null reference type arguments
		/// </summary>
		/// <typeparam name="TArgument">Arbitary reference type</typeparam>
		/// <param name="parameterName">Name of the parameter</param>
		/// <param name="argument">Argument to guard against</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="argument" /> is null</exception>
		[DebuggerStepThrough]
		public static void AgainstNullArgument<TArgument>(string parameterName, TArgument argument)
			where TArgument : class
		{
			if (argument == null)
				throw new ArgumentNullException(nameof(argument));
		}

		/// <summary>
		///     Guards against nullable value type arguments without value
		/// </summary>
		/// <typeparam name="TArgument">Arbitary nullable value type</typeparam>
		/// <param name="parameterName">Name of the parameter</param>
		/// <param name="argument">Argument to guard against</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="argument" /> is null</exception>
		[DebuggerStepThrough]
		public static void AgainstNullArgument<TArgument>(string parameterName, TArgument? argument)
			where TArgument : struct
		{
			if (!argument.HasValue)
				throw new ArgumentNullException(nameof(argument));
		}

		/// <summary>
		///     Guards against null or empty strings
		/// </summary>
		/// <param name="parameterName">Name of the parameter</param>
		/// <param name="argument">Argument to guard against</param>
		/// <exception cref="ArgumentException">Thrown when <paramref name="argument" /> is null or empty</exception>
		[DebuggerStepThrough]
		public static void AgainstNullArgument(string parameterName, string argument)
		{
			if (string.IsNullOrEmpty(argument))
				throw new ArgumentException($"Value of '{parameterName}' cannot be null or empty.");
		}

		/// <summary>
		///     Ensures that a specified condition can be satisfied or throws an exception otherwise
		/// </summary>
		/// <typeparam name="TException">Arbitary exception type implementing <see cref="Exception" /></typeparam>
		/// <param name="condition">Condition to satisfy</param>
		/// <param name="exceptionFactory">Factory delegate for creating an exception of <typeparamref name="TException" /></param>
		[DebuggerStepThrough]
		public static void Requires<TException>(bool condition, Func<TException> exceptionFactory)
			where TException : Exception
		{
			AgainstNullArgument(nameof(exceptionFactory), exceptionFactory);
			if (!condition)
				throw exceptionFactory.Invoke();
		}
	}
}
