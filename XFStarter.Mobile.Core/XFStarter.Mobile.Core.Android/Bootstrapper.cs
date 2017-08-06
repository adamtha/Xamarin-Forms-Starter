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

namespace XFStarter.Mobile.Core.Android
{
    public static class Bootstrapper
    {
        public static void Initialize()
        {
            // You must call this right after Xamarin.Forms.Forms.Init(this, bundle); in MainActivity.cs
            // in order to load the assembly properly for the dependency service
        }
    }
}