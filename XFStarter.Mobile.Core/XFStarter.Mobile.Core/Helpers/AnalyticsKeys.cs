using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFStarter.Mobile.Core.Helpers
{
    public class AnalyticsKeys
    {
        public static string Exception => "Exception";

        public class App
        {
            static string prefix = $"{nameof(App)}";

            public static string Start => $"{prefix} {nameof(Start)}";
            public static string Sleep => $"{prefix} {nameof(Sleep)}";
            public static string Resume => $"{prefix} {nameof(Resume)}";
        }

        public class Culture
        {
            static string prefix = $"{nameof(Culture)}";

            public static string Updated { get; } = $"{prefix} {nameof(Updated)}";
        }
    }
}
