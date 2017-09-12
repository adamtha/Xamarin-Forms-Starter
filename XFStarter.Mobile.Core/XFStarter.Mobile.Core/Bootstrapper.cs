using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFStarter.Mobile.Core.L10N;

namespace XFStarter.Mobile.Core
{
    // This will be called on App C'tor afrer InitializeComponent();
    // and will be used to bootstrap services
    public static class Bootstrapper
    {
        public static bool IsTestEnvironment { get; set; }

        /*
        // Sample localization initialization 
        // this should be in the Xamarin Forms shared project Bootstrapping file
        private static void InitializeLocalization()
        {
            // set the supported languages
            // the manager will set the current language from the application settings

            LocalizationManager.Instance.AddSupportedCultures(new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("he-IL")
            });

            // set the localization resources provider
            // currently only single resource manager is supported
            // can be easily updated to support multiple resource manager using types and dictionaries

            var localizer = new ResourceLocalizer(AppResources.ResourceManager);
            localizer.OnCultureUpdated = new Action<CultureInfo>(ci =>
            {
                AppResources.Culture = ci;
            });

            // Set the generated localizer

            LocalizationManager.Instance.ResourceLocalizer = localizer;

            // in XAML, use the LocalizedStrings from the BaseViewModel to localize strings
            <Label Text="{Binding LocalizedStrings[HelloWorld]}" />

            // localization converter usage
            <cnv:LocalizationConverter x:Key="LocalizationConverter" />
            <TextCell Text="{Binding Title, Converter={StaticResource LocalizationConverter}}" />

            //Translate extention usage
            xmlns:T="clr-namespace:XFStarter.Mobile.Core.L10N;assembly=XFStarter.Mobile.Core"
            <Label Text="{T:Translate HelloWorld}" />
        }
        */

        internal static void Initialize()
        {
            //initialize mobile center
            // use the proper API keys
            MobileCenterHelper.Initialize();

            if(IsTestEnvironment)
            {
                //DependencyService.Register<SomeInterface, SomeMockService>();
            }
        }
    }
}
