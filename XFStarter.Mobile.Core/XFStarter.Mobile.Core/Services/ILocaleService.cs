using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFStarter.Mobile.Core.Services
{
    public interface ILocaleService
    {
        CultureInfo GetLocale();
        void SetLocale(CultureInfo culture);
    }
}
