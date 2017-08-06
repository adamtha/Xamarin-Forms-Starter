using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace XFStarter.Mobile.Core.Logging
{
    public static class ILoggerExtentions
    {
        public static void TrackAnalytics(this ILogger logger, string name, IDictionary<string, string> properties = null)
        {
            var propsVal = string.Empty;
            var props = properties?.Select(kvp => $"{kvp.Key}:{kvp.Value ?? string.Empty}");
            if(props?.Any() == true)
            {
                propsVal = ", properties:" + string.Join("|", props);
            }
            logger.Debug($"tracking event: {name}{propsVal}");

            Microsoft.Azure.Mobile.Analytics.Analytics.TrackEvent(name, properties);
        }

        public static void TrackAnalytics(this ILogger logger, Exception ex, [CallerMemberName] string memberName = "")
        {
            try
            {
                const int MaxPropertyLength = 64;

                if(ex is AggregateException)
                {
                    ex = (ex as AggregateException).Flatten();
                }

                var stack = ex.StackTrace;
                if(stack.Length > MaxPropertyLength)
                {
                    stack = stack.Substring(0, MaxPropertyLength);
                }

                if(!string.IsNullOrWhiteSpace(memberName))
                {
                    memberName = $":{memberName}";
                }

                logger.TrackAnalytics($"{ex.GetType().Name}{memberName}", new Dictionary<string, string>
                {
                    { "Message", ex.Message },
                    { "StackTrace", stack}
                });
            }
            catch
            {
            }
        }

        public static void Debug(this ILogger logger, string format, [CallerMemberName] string memberName = "", params object[] args)
        {
            logger.WriteLog(LogLevel.Debug, format, memberName, args);
        }

        public static void Info(this ILogger logger, string format, [CallerMemberName] string memberName = "", params object[] args)
        {
            logger.WriteLog(LogLevel.Information, format, memberName, args);
        }

        public static void Warn(this ILogger logger, string format, [CallerMemberName] string memberName = "", params object[] args)
        {
            logger.WriteLog(LogLevel.Warning, format, memberName, args);
        }

        public static void Warn(this ILogger logger, Exception ex, string message = "", [CallerMemberName] string memberName = "")
        {
            logger.WriteLog(LogLevel.Warning, ex, message, memberName);
        }

        public static void Error(this ILogger logger, Exception ex, string message = "", [CallerMemberName] string memberName = "")
        {
            logger.WriteLog(LogLevel.Error, ex, message, memberName);
        }

        public static void Critical(this ILogger logger, Exception ex, string message = "", [CallerMemberName] string memberName = "")
        {
            logger.WriteLog(LogLevel.Critical, ex, message, memberName);
        }
    }
}
