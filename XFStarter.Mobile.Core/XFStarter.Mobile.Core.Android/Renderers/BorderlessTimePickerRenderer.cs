using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFStarter.Mobile.Core.Android.Renderers;

[assembly: ExportRenderer(typeof(TimePicker), typeof(BorderlessTimePickerRenderer))]

namespace XFStarter.Mobile.Core.Android.Renderers
{
    public class BorderlessTimePickerRenderer : TimePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
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