using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFStarter.Mobile.Core.Android.Renderers;

[assembly: ExportRenderer(typeof(Picker), typeof(BorderlessPickerRenderer))]

namespace XFStarter.Mobile.Core.Android.Renderers
{
    public class BorderlessPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if(Control != null)
            {
                Control.InputType = global::Android.Text.InputTypes.TextFlagNoSuggestions;
                Control.TextAlignment = global::Android.Views.TextAlignment.Center;
                Control.Gravity = global::Android.Views.GravityFlags.CenterHorizontal;
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
            }
        }
    }
}