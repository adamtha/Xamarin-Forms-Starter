using System;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;
using XFStarter.Mobile.Core.Android.Services;
using XFStarter.Mobile.Core.Services;

[assembly: Dependency(typeof(LocaleService))]

namespace XFStarter.Mobile.Core.Android.Services
{
    public class LocaleService : ILocaleService
    {
        public CultureInfo GetLocale()
        {
            var defaultLocale = "en-US";

            var currLocale = Java.Util.Locale.Default.ToString().Replace("_", "-");
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