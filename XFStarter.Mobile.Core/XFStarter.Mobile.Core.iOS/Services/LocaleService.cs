using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using Foundation;
using UIKit;
using Xamarin.Forms;
using XFStarter.Mobile.Core.Services;
using XFStarter.Mobile.Core.iOS.Services;

[assembly: Dependency(typeof(LocaleService))]

namespace XFStarter.Mobile.Core.iOS.Services
{
    public class LocaleService : ILocaleService
    {
        public CultureInfo GetLocale()
        {
            var defaultLocale = "en-US";

            var currLocale = NSLocale.CurrentLocale.ToString().Replace("_", "-");
            try
            {
                return new CultureInfo(currLocale);
            }
            catch(CultureNotFoundException) { }

            return new CultureInfo(defaultLocale);
        }

        public void SetLocale(CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }
    }
}