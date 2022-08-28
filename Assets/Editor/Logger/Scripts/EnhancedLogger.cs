using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Editor.Logger.Scripts {
    public enum LogType {
        Regular,
        Warning,
        Error,
        Success,
    }

    public static class EnhancedLogger {
        #region Events

        public static Action<LoggerPlaceholder> OnLogWritten;

        #endregion

        #region Logs

        public static void Log(this Object obj, params object[] message) {
            WriteLog(Debug.Log, LogType.Regular, obj, message);
        }

        public static void LogWarning(this Object obj, params object[] message) {
            WriteLog(Debug.LogWarning, LogType.Warning, obj, message);
        }

        public static void LogError(this Object obj, params object[] message) {
            WriteLog(Debug.LogError, LogType.Error, obj, message);
        }

        public static void LogSuccess(this Object obj, params object[] message) {
            WriteLog(Debug.Log, LogType.Success, obj, message);
        }

        #endregion

        #region Utility

        private static void WriteLog(Action<string, Object> logFunctions, LogType prefix, Object obj,
            params object[] message) {
#if UNITY_EDITOR
            logFunctions(
                $"{prefix.GetLogTypeColor()} {obj.name.GetColor("lightblue")}: {string.Join(";\n", message)}\n ", obj);
#endif
            var logPlaceholder = new LoggerPlaceholder(prefix, obj, message);
            OnLogWritten?.Invoke(logPlaceholder);
        }

        public static string GetColor(this string str, string color) {
            return $"<color={color}>{str}</color>";
        }

        private static string GetLogTypeColor(this LogType logType) {
            return logType switch {
                LogType.Regular => string.Empty,
                LogType.Warning => logType.ToString().GetColor("yellow"),
                LogType.Error => logType.ToString().GetColor("red"),
                LogType.Success => logType.ToString().GetColor("green"),
                _ => throw new ArgumentOutOfRangeException(nameof(logType), logType, null)
            };
        }

        #endregion
    }
}