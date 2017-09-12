using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFStarter.Mobile.Core.L10N
{
    public interface IResourceLocalizer
    {
        Action<CultureInfo> OnCultureUpdated { get; set; }
        string Localize(string key);
        string Localize(string key, CultureInfo culture);
    }
}
