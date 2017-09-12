using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFStarter.Mobile.Core.L10N;

namespace XFStarter.Mobile.Core.Converters
{
    public class LocalizationConverter : IValueConverter
    {
        private static ILocalizedStrings LocalizedStrings => LocalizationManager.Instance;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var key = value as string;
            if(key == null)
            {
                return value;
            }

            return LocalizedStrings[key] ?? value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
