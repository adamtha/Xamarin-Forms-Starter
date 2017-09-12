using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFStarter.Mobile.Core.L10N
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        private static ILocalizedStrings LocalizedStrings => LocalizationManager.Instance;

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if(string.IsNullOrWhiteSpace(Text))
            {
                return string.Empty;
            }

            return LocalizedStrings[Text] ?? string.Empty;
        }
    }
}
