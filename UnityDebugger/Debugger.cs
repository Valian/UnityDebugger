using System;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

namespace UnityDebugger
{
    /// <summary>
    /// Enum describing logging level of Debugger. 
    /// Info > Warning > Error > Exception > None
    /// </summary>
    public enum LogLevel
    {
        None, 
        Exception,
        Error,
        Warning,
        Info
    }

    public class AssertException : Exception
    {
        public AssertException() { }
        public AssertException(string message) : base(message) { }
        public AssertException(string message, Exception innerException) : base(message, innerException) { }
    }

    public static class Debugger
    {
        /// <summary>
        /// If false, Debugger does nothing. 
        /// Default value: Debug.isDebugBuild
        /// </summary>
        public static bool Enabled { get; set; }

        /// <summary>
        /// Log level of Debugger.
        /// Default value: LogLevel.Info
        /// </summary>
        public static LogLevel LogLevel { get; set; }

        static Debugger()
        {
            Enabled = Debug.isDebugBuild;
            LogLevel = LogLevel.Info;
        }

        #region Asserts

        /// <summary>
        /// Throws AssertException if statement is false. Works only when Debugger is Enabled.
        /// </summary>
        /// <param name="statement">Statement to check</param>
        /// <param name="name">Name of statement</param>
        public static void Assert(bool statement, string name = "Statement")
        {
            if (Enabled && !statement)
            {
                throw new AssertException(name + " is false!");
            }
        }

        /// <summary>
        /// Asserts if obj is null. Works only when Debugger is Enabled.
        /// </summary>
        /// <param name="obj">Object to check.</param>
        /// <param name="name">Name of a object</param>
        /// <param name="context">Context for a check (usually containing class).</param>
        public static void AssertNotNull(object obj, string name, Object context)
        {
            if (Enabled && obj.Equals(null))
            {
                Debug.LogError(name + " in object " + context.name + " ( " + context.GetType() + " ) is null!");
            }
        }

        #endregion

        #region Logging

        /// <summary>
        /// Writes info to console. Works only when Debugger is Enabled.
        /// </summary>
        /// <param name="message">Info to write.</param>
        public static void Log(string message)
        {
            if (Enabled && LogLevel >= LogLevel.Info)
            {
                Debug.Log(message);
            }
        }

        /// <summary>
        /// Writes warning to console. Works only when Debugger is Enabled.
        /// </summary>
        /// <param name="message">Warning to write.</param>
        public static void LogWarning(string message)
        {
            if (Enabled && LogLevel >= LogLevel.Warning)
            {
                Debug.LogWarning(message);
            }
        }

        /// <summary>
        /// Writes error to console. Works only when Debugger is Enabled.
        /// </summary>
        /// <param name="message">Error to write.</param>
        public static void LogError(string message)
        {
            if (Enabled && LogLevel >= LogLevel.Error)
            {
                Debug.LogError(message);
            }
        }

        /// <summary>
        /// Writes exception to console. Works only when Debugger is Enabled.
        /// </summary>
        /// <param name="exception">Exception to write.</param>
        public static void LogException(Exception exception)
        {
            if (Enabled && LogLevel >= LogLevel.Exception)
            {
                Debug.LogException(exception);
            }
        }

        #endregion
    }
}
