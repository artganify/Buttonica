namespace Pressiah.Diagnostics.Logging.Targets
{
    /// <summary>
    ///     Represents a destination for <see cref="LogEvent">log events</see>
    /// </summary>
    public interface ILogTarget
    {
        /// <summary>
        ///     Emits the specified <see cref="LogEvent" />
        /// </summary>
        void Emit(LogEvent logEvent);
    }
}