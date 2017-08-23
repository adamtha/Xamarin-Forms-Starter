using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Foundation;
using UIKit;
using XFStarter.Mobile.Core.iOS.Logging;
using XFStarter.Mobile.Core.Logging;

[assembly: Xamarin.Forms.Dependency(typeof(Logger))]

namespace XFStarter.Mobile.Core.iOS.Logging
{
    public class Logger : ILogger
    {
        public string Name { get; set; } = "iOS.APP";

        public Logger() { }

        public Logger([CallerMemberName] string name = "iOS.APP")
        {
            Name = name;
        }

        public void WriteLog(LogLevel logLevel, string message, [CallerMemberName] string memberName = "")
        {
            Console.WriteLine($"{logLevel}|{memberName}|{message}");
            this.CacheLog(logLevel, message, memberName);
        }

        public void WriteLog(LogLevel logLevel, string format, [CallerMemberName] string memberName = "", params object[] args)
        {
            Console.WriteLine($"{logLevel}|{memberName}|{string.Format(format, args)}");
            this.CacheLog(logLevel, string.Format(format, args), memberName);
        }

        public void WriteLog(LogLevel logLevel, Exception ex, string message = "", [CallerMemberName] string memberName = "")
        {
            Console.WriteLine($"{logLevel}|{memberName}|{message}|{ex}");
            this.TrackAnalytics(ex, memberName);
            this.CacheLog(logLevel, message, memberName, ex);
        }
    }
}