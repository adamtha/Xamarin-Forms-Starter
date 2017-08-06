using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using XFStarter.Mobile.Core.Services;
using UIKit;
using XFStarter.Mobile.Core.iOS.Services;
using Xamarin.Forms;
using System.Security.Cryptography;
using XFStarter.Mobile.Core.Helpers;

[assembly: Dependency(typeof(DeviceInfo))]

namespace XFStarter.Mobile.Core.iOS.Services
{
    public class DeviceInfo : IDeviceInfo
    {
        public string Id => UIDevice.CurrentDevice.IdentifierForVendor.AsString();

        public string Model => UIDevice.CurrentDevice.Model;

        public string Version => UIDevice.CurrentDevice.SystemVersion;

        public Platform Platform => Platform.iOS;

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