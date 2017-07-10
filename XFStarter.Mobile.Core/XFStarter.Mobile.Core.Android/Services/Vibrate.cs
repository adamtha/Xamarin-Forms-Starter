using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XFStarter.Mobile.Core.Android.Services;
using XFStarter.Mobile.Core.Logging;
using XFStarter.Mobile.Core.Services;

[assembly: Xamarin.Forms.Dependency(typeof(Vibrate))]

namespace XFStarter.Mobile.Core.Android.Services
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

            using(var v = Application.Context.GetSystemService(Context.VibratorService) as Vibrator)
            {
                if(!v.HasVibrator)
                {
                    return;
                }

                try
                {
                    v.Vibrate(milliseconds);
                }
                catch(Exception ex)
                {
                    Logger.Error(ex);
                }
            }
        }
    }
}