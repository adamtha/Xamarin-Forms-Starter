using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFStarter.Mobile.Core
{
    // This will be called on App C'tor afrer InitializeComponent();
    // and will be used to bootstrap services
    public static class Bootstrapper
    {
        public static bool IsTestEnvironment { get; set; }

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
