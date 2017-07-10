using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AudioToolbox;
using Foundation;
using XFStarter.Mobile.Core.Logging;
using XFStarter.Mobile.Core.Services;
using UIKit;
using XFStarter.Mobile.Core.iOS.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(Vibrate))]

namespace XFStarter.Mobile.Core.iOS.Services
{
    public class Vibrate : IVibrate
    {
        private static ILogger Logger = LoggerFactory.CreateLogger();

        public void Vibration(int milliseconds = 500)
        {
            if(milliseconds < 0)
            {
                return;
            }

            try
            {
                SystemSound.Vibrate.PlaySystemSound();
            }
            catch(Exception ex)
            {
                Logger.Error(ex);
            }
        }
    }
}