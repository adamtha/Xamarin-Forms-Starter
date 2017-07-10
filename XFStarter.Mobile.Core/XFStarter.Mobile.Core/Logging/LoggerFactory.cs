using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFStarter.Mobile.Core.Logging
{
    public class LoggerFactory
    {
        public static ILogger CreateLogger<T>()
        {
            return CreateLogger(typeof(T).Name);
        }

        public static ILogger CreateLogger([CallerMemberName] string memberName = "")
        {
            try
            {
                var logger = DependencyService.Get<ILogger>();
                logger.Name = memberName;
                return logger;
            }
            catch
            {
                return new DebugLogger(memberName);
            }
        }
    }
}
