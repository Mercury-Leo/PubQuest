using System;

namespace Editor.Logger.Scripts {
    public class LoggerPlaceholder {
        public LogType LogType { get; set; }

        public object Obj { get; set; }

        public object[] Message { get; set; }

        public LoggerPlaceholder(LogType logType, object obj, object[] message) {
            LogType = logType;
            Obj = obj;
            Message = message;
        }
    }
}