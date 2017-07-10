using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using XFStarter.Mobile.Core.Android.Logging;
using XFStarter.Mobile.Core.Logging;

[assembly: Xamarin.Forms.Dependency(typeof(Logger))]

namespace XFStarter.Mobile.Core.Android.Logging
{
    public class Logger : ILogger
    {
        public string Name { get; set; } = "Android.APP";

        public Logger() { }

        public Logger([CallerMemberName] string name = "Android.APP")
        {
            Name = name;
        }

        public ILogger ForThisClass([CallerMemberName] string memberName = "")
        {
            Name = memberName;
            return this;
        }

        public void WriteLog(LogLevel logLevel, string message, [CallerMemberName] string memberName = "")
        {
            switch(logLevel)
            {
                case LogLevel.Trace:
                case LogLevel.Debug:
                    Log.Debug(memberName, message);
                    break;
                case LogLevel.Information:
                    Log.Info(memberName, message);
                    break;
                case LogLevel.Warning:
                    Log.Warn(memberName, message);
                    break;
                case LogLevel.Error:
                    Log.Error(memberName, message);
                    break;
                case LogLevel.Critical:
                    Log.Wtf(memberName, message);
                    break;
            }
        }

        public void WriteLog(LogLevel logLevel, string format, [CallerMemberName] string memberName = "", params object[] args)
        {
            switch(logLevel)
            {
                case LogLevel.Trace:
                case LogLevel.Debug:
                    Log.Debug(memberName, format, args);
                    break;
                case LogLevel.Information:
                    Log.Info(memberName, format, args);
                    break;
                case LogLevel.Warning:
                    Log.Warn(memberName, format, args);
                    break;
                case LogLevel.Error:
                    Log.Error(memberName, format, args);
                    break;
                case LogLevel.Critical:
                    Log.Wtf(memberName, format, args);
                    break;
            }
        }

        public void WriteLog(LogLevel logLevel, Exception ex, string message = "", [CallerMemberName] string memberName = "")
        {
            var throwable = Java.Lang.Throwable.FromException(ex);
            switch(logLevel)
            {
                case LogLevel.Trace:
                case LogLevel.Debug:
                    Log.Debug(memberName, throwable, message);
                    break;
                case LogLevel.Information:
                    Log.Info(memberName, throwable, message);
                    break;
                case LogLevel.Warning:
                    Log.Warn(memberName, throwable, message);
                    break;
                case LogLevel.Error:
                    Log.Error(memberName, throwable, message);
                    this.TrackAnalytics(ex, memberName);
                    break;
                case LogLevel.Critical:
                    Log.Wtf(memberName, throwable, message);
                    this.TrackAnalytics(ex, memberName);
                    break;
            }
        }
    }
}