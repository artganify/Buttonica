using System;
using System.Collections.Generic;

namespace Buttonica.Engine.Core.Collections
{
	/// <summary>
	///     Extensions for <see cref="IEnumerable{T}" />
	/// </summary>
	public static class EnumerableExtensions
	{
		/// <summary>
		///     Applies an action delegate of each item of an <see cref="IEnumerable{T}" />
		/// </summary>
		public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
		{
			if (enumerable == null)
				return;
			foreach (var item in enumerable)
				action(item);
		}
	}
}