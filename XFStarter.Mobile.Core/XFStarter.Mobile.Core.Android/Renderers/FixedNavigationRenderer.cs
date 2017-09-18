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
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;
using XFStarter.Mobile.Core.Android.Renderers;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(FixedNavigationRenderer))]

namespace XFStarter.Mobile.Core.Android.Renderers
{
    // WARNING
    // There is a crash happens for unknown reason:
    // System.MissingMethodException: No constructor found for
    //   Xamarin.Forms.Platform.Android.AppCompat.NavigationPageRenderer::.ctor(System.IntPtr, Android.Runtime.JniHandleOwnership)
    // see https://bugzilla.xamarin.com/show_bug.cgi?id=40258
    // --
    // As a solution we override NavigationPageRenderer to provide the constructor.
    // Although then there is a NullReferenceException happens in
    //  OnDetachedFromWindow() method which we are fixing too.
    public class FixedNavigationRenderer : NavigationPageRenderer
    {
        public FixedNavigationRenderer() : base() { }

        public FixedNavigationRenderer(IntPtr javaReference, JniHandleOwnership transfer) : base() { }

        protected override void OnDetachedFromWindow()
        {
            if(Element == null)
            {
                return;
            }

            base.OnDetachedFromWindow();
        }
    }
}