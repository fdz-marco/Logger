﻿namespace glitcher.core
{
    /// <summary>(Class: Static~Global) Simple Logger</summary>
    /// <remarks>
    /// Author: Marco Fernandez (marcofdz.com / glitcher.dev)<br/>
    /// Last modified: 2024.06.15 - June 15, 2024
    /// </remarks>
    public static class Logger
    {
        // ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~

        #region Properties (Private / Public / Getters|Setters / Events)

        public static List<Log> logList { get; set; } = new List<Log>();
        public static bool debug { get; set; } = true;
        public static bool disabled { get; set; } = false;
        public static bool includeCaller { get; set; } = true;

        public static event EventHandler<LogEvent>? ChangeOccurred;

        #endregion

        // ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~

        #region Constructor / Settings / Initialization Tasks

        /// <summary>Class constructor.</summary>
        static Logger()
        {
            if (logList == null)
            {
                logList = new List<Log>();
            }
        }

        #endregion

        // ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~

        #region Methods

        /// <summary> 
        /// Add Entry to Log.<br/>
        /// <example>
        /// Example:<br/>
        /// <code>Logger.Add(LogLevel.Error, "Class Name", "Error on Step 1", "More Info);</code>
        /// </example>
        /// </summary>
        /// <param name="level">Severity Level</param>
        /// <param name="group">Group</param>
        /// <param name="message">Message</param>
        /// <param name="whisper">Whisper (More information)</param>
        /// <returns>(void)</returns>
        public static void Add(LogLevel level, string group, string message, string whisper = "")
        {
            if (disabled) 
                return;

            Log log = new Log();
            log.DateTime = DateTime.Now;
            log.LogLevel = level; 
            log.Group = group;
            log.Message = message;
            log.Whisper = whisper;

            var stackFrame = new System.Diagnostics.StackTrace().GetFrame(1);
            var methodInfo = (stackFrame != null) ? stackFrame.GetMethod() : null; 
            var className = (methodInfo?.ReflectedType != null) ? methodInfo.ReflectedType.FullName : null;
            log.Caller = (className != null) ? className : "";
            
            string debugMsg = $"[{log.DateTime}][{log.LogLevel}][{log.Group}] {log.Message}";
            debugMsg += string.IsNullOrEmpty(log.Whisper) ? string.Empty : $" ({log.Whisper})";
            debugMsg += includeCaller ? $" <{log.Caller}>" : string.Empty;

            _d(debugMsg);
            logList.Add(log);
            NotifyChange("add", log);
        }

        /// <summary>Get a JSON of all logs.</summary>
        /// <returns>(string) JSON with alll the logs.</returns>
        public static string GetAllJSON()
        {
            return System.Text.Json.JsonSerializer.Serialize(logList);
        }

        /// <summary>Clear all logs.</summary>
        /// <returns>(void)</returns>
        public static void ClearAll()
        {
            logList.Clear();
            NotifyChange("clear");
        }

        /// <summary>Alias to write a message on console.</summary>
        /// <param name="message">Message to write</param>
        /// <returns>(void)</returns>
        public static void _d(string message)
        {
            if (debug)
            {
                System.Diagnostics.Debug.WriteLine(message);
            }
        }

        #endregion

        // ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~

        #region Notifiers / Event Handlers

        /// <summary>Notify a change on Log.</summary>
        /// <returns>(void)</returns>
        private static void NotifyChange(string eventType, dynamic? varValue = null)
        {
            if (ChangeOccurred != null)
            {
                ChangeOccurred.Invoke(typeof(Logger), new LogEvent(eventType, varValue));
            }
        }

        #endregion

        // ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~
    }
}