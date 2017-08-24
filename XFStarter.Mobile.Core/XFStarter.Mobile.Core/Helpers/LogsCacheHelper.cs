using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFStarter.Mobile.Core.Logging;

namespace XFStarter.Mobile.Core.Helpers
{
    public class LogItem
    {
        private Guid Id { get; } = Guid.NewGuid();
        public DateTime Date { get; } = DateTime.UtcNow;
        public LogLevel Level { get; set; } = LogLevel.Off;
        public string Name { get; set; }
        public string Method { get; set; }
        public string Message { get; set; }
        public Exception Error { get; set; }

        public override bool Equals(object obj)
        {
            return (obj as LogItem)?.Id.Equals(Id) == true;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Date:O}|{Name}|{Method}|{Level}|{Message}|{Error}".Trim('|');
        }
    }

    public static class LogsCacheHelper
    {
        private static FixedSizedQueue<LogItem> LogsQueue { get; } = new FixedSizedQueue<LogItem>(1000);
        private static readonly object syncObject = new object();

        public static void AddLog(LogItem item)
        {
            lock(syncObject)
            {
                LogsQueue.Enqueue(item);
            }
        }

        public static IList<LogItem> GetLogs(int count = 1000)
        {
            lock(syncObject)
            {
                return LogsQueue.Take(count).ToArray();
            }
        }
    }
}
