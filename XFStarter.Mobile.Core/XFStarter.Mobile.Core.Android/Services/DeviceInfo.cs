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
using static Android.Provider.Settings;
using XFStarter.Mobile.Core.Services;
using XFStarter.Mobile.Core.Android.Services;
using System.Security.Cryptography;
using XFStarter.Mobile.Core.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceInfo))]

namespace XFStarter.Mobile.Core.Android.Services
{
    public class DeviceInfo : IDeviceInfo
    {
        public string Id => Secure.GetString(Application.Context.ContentResolver, Secure.AndroidId).ToUpper();

        public string Model => Build.Model;

        public string Version => Build.VERSION.Release;

        public Platform Platform => Platform.Android;

        public byte[] HashedId
        {
            get
            {
                using(var sha384 = new SHA384CryptoServiceProvider())
                {
                    var bytes = ByteStringHelper.FromHexString(Id);
                    return sha384.ComputeHash(bytes);
                }
            }
        }
    }
}