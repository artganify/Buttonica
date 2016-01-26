using System;using System.Diagnostics;
// ReSharper disable All
internal static class _guard
{[DebuggerStepThrough]
public static void AgainstNullArgument<TArgument>(string parameterName,TArgument argument)
where TArgument:class
{if(argument==null)
throw new ArgumentNullException(nameof(argument));}
[DebuggerStepThrough]
public static void AgainstNullArgument<TArgument>(string parameterName,TArgument?argument)
where TArgument:struct
{if(!argument.HasValue)
throw new ArgumentNullException(nameof(argument));}
[DebuggerStepThrough]
public static void AgainstNullArgument(string parameterName,string argument)
{if(string.IsNullOrEmpty(argument))
throw new ArgumentException($"Value of '{parameterName}' cannot be null or empty.");}
[DebuggerStepThrough]
public static void Requires<TException>(bool condition,Func<TException>exceptionFactory)
where TException:Exception
{AgainstNullArgument(nameof(exceptionFactory),exceptionFactory);if(!condition)
throw exceptionFactory.Invoke();}}