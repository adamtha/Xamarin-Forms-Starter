using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

namespace XFStarter.Mobile.Core
{
    public class MobileCenterHelper
    {
        /// <summary>
        /// Initialize Mobile Center with the API token keys
        /// </summary>
        /// <param name="AndroidKey">
        /// The android secret key in the form of
        /// android={Your Android APP secret here}
        /// </param>
        /// <param name="IosKey">
        /// The ios secret key in the form of
        /// ios={Your Android APP secret here}
        /// </param>
        /// <param name="UwpKey">
        /// The universal windows programs secret key in the form of
        /// uwp={Your Android APP secret here}
        /// </param>
        public static void Initialize(string AndroidKey = "", string IosKey = "", string UwpKey = "")
        {
            // if Ii App updates required than add the Microsoft.Azure.Mobile.Distribute package as well
            // https://docs.microsoft.com/en-us/mobile-center/sdk/distribute/xamarin
        
            MobileCenter.Start(AndroidKey + IosKey + UwpKey, typeof(Analytics), typeof(Crashes));
        }
    }
}
