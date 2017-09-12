using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace XFStarter.Mobile.Core.L10N
{
    public class ResourceLocalizer : IResourceLocalizer
    {
        private ResourceManager Localizer { get; set; }

        public Action<CultureInfo> OnCultureUpdated { get; set; }

        public ResourceLocalizer(ResourceManager localizer)
        {
            Localizer = localizer;
        }

        public string Localize(string key)
        {
            return Localizer.GetString(key);
        }

        public string Localize(string key, CultureInfo culture)
        {
            return Localizer.GetString(key, culture);
        }
    }
}
