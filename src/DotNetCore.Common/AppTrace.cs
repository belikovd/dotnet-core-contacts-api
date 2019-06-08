using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace DotNetCore.Common
{
    public static class AppTrace
    {
        #region "Public Methods"

        public static void Info(string message, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string callerFilePath = "")
        {
            string caller = FormatCaller(callerMemberName, callerFilePath);
            Trace.TraceInformation($"{UtcNow()} | {caller} | {message}");
        }

        public static void Error(string message, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string callerFilePath = "")
        {
            string caller = FormatCaller(callerMemberName, callerFilePath);
            Trace.TraceError($"{UtcNow()} | {caller} | {message}");
        }

        public static void Warn(string message, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string callerFilePath = "")
        {
            string caller = FormatCaller(callerMemberName, callerFilePath);
            Trace.TraceWarning($"{UtcNow()} | {caller} | {message}");
        }

        #endregion

        #region "Private Methods"

        private static string FormatCaller(string callerMemberName, string callerFilePath)
        {
            string callerMethod = string.IsNullOrWhiteSpace(callerMemberName)
                ? "Undefined"
                : callerMemberName;

            string callerFileName = string.IsNullOrWhiteSpace(callerFilePath)
                ? "Undefined"
                : Path.GetFileNameWithoutExtension(callerFilePath);

            return $"{callerFileName} -> {callerMethod}";
        }

        private static string UtcNow()
        {
            return DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        #endregion
    }
}
