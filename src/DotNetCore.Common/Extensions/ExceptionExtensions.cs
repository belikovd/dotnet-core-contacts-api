using System;

namespace DotNetCore.Common.Extensions
{
    public static class ExceptionExtensions
    {
        public static void Trace(this Exception exception)
        {
            AppTrace.Error($"{exception ?? new Exception("Unknown exception.")}");
        }
    }
}
