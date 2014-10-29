using System;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

namespace UnityDebugger
{
    public class Debugger
    {
        #region Asserts

        public static void Assert(bool statement, string name = "Assert")
        {
            if (Debug.isDebugBuild && !statement)
            {
                throw new Exception(name  + " is false!");
            }
        }

        public static void AssertNotNull(object obj, string name, Object context)
        {
            if (Debug.isDebugBuild && obj == null)
            {
                Debug.LogError(name + " in object " + context.name + " ( " + context.GetType() + " ) is null!");
            }
        }

        public static void AssertNotNull(Object obj, string name, Object context)
        {
            if (Debug.isDebugBuild && obj == null)
            {
                Debug.LogError(name + " in object " + context.name + " ( " + context.GetType() + " ) is null!");
            }
        }

        #endregion

        #region Logging

        public static void Log(string message)
        {
            if (Debug.isDebugBuild)
            {
                Debug.Log(message);
            }
        }

        public static void LogWarning(string message)
        {
            if (Debug.isDebugBuild)
            {
                Debug.LogWarning(message);
            }
        }

        public static void LogError(string message)
        {
            if (Debug.isDebugBuild)
            {
                Debug.LogError(message);
            }
        }
        public static void LogException(Exception exception)
        {
            if (Debug.isDebugBuild)
            {
                Debug.LogException(exception);
            }
        }

        #endregion
    }
}
