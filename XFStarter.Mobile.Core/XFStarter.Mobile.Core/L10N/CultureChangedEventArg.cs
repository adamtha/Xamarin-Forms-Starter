using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFStarter.Mobile.Core.L10N
{
    public class CultureChangedEventArg : EventArgs
    {
        public CultureInfo Culture { get; }

        public CultureChangedEventArg(CultureInfo culture)
        {
            Culture = culture;
        }
    }
}
