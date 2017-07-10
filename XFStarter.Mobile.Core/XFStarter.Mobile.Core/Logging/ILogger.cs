using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace XFStarter.Mobile.Core.Logging
{
    public interface ILogger
    {
        /// <summary>
        /// The <see cref="ILogger"/> name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Write a log entry
        /// </summary>
        /// <param name="logLevel">The level of the log entry.</param>
        /// <param name="message">The log message</param>
        /// <param name="memberName">The caller name of the log method</param>
        /// <param name="exception">The exception related to this entry.</param>
        void WriteLog(LogLevel logLevel, string message, [CallerMemberName] string memberName = "");

        /// <summary>
        /// Set logger for the caller class name
        /// </summary>
        /// <param name="memberName">The caller name</param>
        ILogger ForThisClass([CallerMemberName] string memberName = "");

        /// <summary>
        /// Write a log entry
        /// </summary>
        /// <param name="logLevel">The level of the log entry.</param>
        /// <param name="format">Format string of the log message.</param>
        /// <param name="memberName">The caller name of the log method</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        void WriteLog(LogLevel logLevel, string format, [CallerMemberName] string memberName = "", params object[] args);

        /// <summary>
        /// Write a log entry
        /// </summary>
        /// <param name="logLevel">The level of the log entry.</param>
        /// <param name="ex">The exception related to this entry.</param>
        /// <param name="message">The log message</param>
        /// <param name="memberName">The caller name of the log method</param>
        void WriteLog(LogLevel logLevel, Exception ex, string message = "", [CallerMemberName] string memberName = "");
    }
}
