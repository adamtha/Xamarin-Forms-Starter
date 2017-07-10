using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(XFStarter.Mobile.Core.Logging.DebugLogger))]

namespace XFStarter.Mobile.Core.Logging
{
    public class DebugLogger : ILogger
    {
        public string Name { get; set; } = "DebugLogger";

        public DebugLogger() { }

        public DebugLogger([CallerMemberName] string name = "DebugLogger")
        {
            Name = name;
        }

        public void WriteLog(LogLevel logLevel, string message, [CallerMemberName] string memberName = "")
        {
            if(logLevel == LogLevel.Off)
            {
                return;
            }

            System.Diagnostics.Debug.WriteLine($"{DateTime.Now}|{logLevel}|{memberName}|{message}");
        }

        public void WriteLog(LogLevel logLevel, string format, [CallerMemberName] string memberName = "", params object[] args)
        {
            WriteLog(logLevel, string.Format(format, args), memberName);
        }

        public void WriteLog(LogLevel logLevel, Exception ex, string message = "", [CallerMemberName] string memberName = "")
        {
            WriteLog(logLevel, $"{message}|{ex}", memberName);
        }
    }
}
