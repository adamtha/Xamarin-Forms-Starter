using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFStarter.Mobile.Core.Converters
{
    public class IConvertibleConverter : IValueConverter
    {
        public string ToType { get; set; }
        public string FromType { get; set; }

        #region IValueConverter Members

        private object ConvertType(object value, Type targetType, CultureInfo culture)
        {
            if(value == null || targetType == null)
            {
                return value;
            }
            return System.Convert.ChangeType(value, targetType, culture);
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConvertType(value, Type.GetType(ToType, false), culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConvertType(value, Type.GetType(FromType, false), culture);
        }

        #endregion
    }
}
