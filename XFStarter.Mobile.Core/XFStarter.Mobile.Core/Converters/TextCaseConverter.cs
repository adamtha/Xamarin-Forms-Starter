using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFStarter.Mobile.Core.Converters
{
    public enum TextCase
    {
        None,
        LowerCase,
        UpperCase
        //TitleCase
    }

    public class TextCaseConverter : IValueConverter
    {
        public TextCase ToCase { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string text = value as string;
            if(text == null)
            {
                return value;
            }

            switch(ToCase)
            {
                case TextCase.LowerCase: return culture.TextInfo.ToLower(text);
                case TextCase.UpperCase: return culture.TextInfo.ToUpper(text);
                //case TextCase.TitleCase: return culture.TextInfo.ToTitleCase(text);
                default:
                    return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
