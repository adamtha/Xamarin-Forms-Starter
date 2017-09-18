using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFStarter.Mobile.Core.iOS.Renderers;

[assembly: ExportRenderer(typeof(TimePicker), typeof(BorderlessTimePickerRenderer))]

namespace XFStarter.Mobile.Core.iOS.Renderers
{
    public class BorderlessTimePickerRenderer : TimePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
        {
            base.OnElementChanged(e);

            if(Control != null)
            {
                Control.SpellCheckingType = UITextSpellCheckingType.No;
                Control.TextAlignment = UITextAlignment.Center;
                Control.BorderStyle = UITextBorderStyle.None;

                var timePicker = Control.InputView as UIDatePicker;
                if(timePicker != null)
                {
                    // remove AM/PM
                    timePicker.Locale = new NSLocale("no_nb");
                }
            }
        }
    }
}