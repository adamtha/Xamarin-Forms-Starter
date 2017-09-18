using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFStarter.Mobile.Core.iOS.Renderers;

[assembly: ExportRenderer(typeof(Picker), typeof(BorderlessPickerRenderer))]

namespace XFStarter.Mobile.Core.iOS.Renderers
{
    public class BorderlessPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if(Control != null)
            {
                Control.SpellCheckingType = UITextSpellCheckingType.No;
                Control.TextAlignment = UITextAlignment.Center;
                Control.BorderStyle = UITextBorderStyle.None;
            }
        }
    }
}