using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFStarter.Mobile.Core.iOS.Renderers;

[assembly: ExportRenderer(typeof(Button), typeof(ButtonDisabledTextColorRenderer))]

namespace XFStarter.Mobile.Core.iOS.Renderers
{
    public class ButtonDisabledTextColorRenderer : ButtonRenderer
    {
        private static UIColor DisabledColor => UIColor.White;

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if(Control == null)
            {
                return;
            }

            var title = new NSAttributedString(Control.CurrentTitle, new UIStringAttributes { ForegroundColor = DisabledColor });
            Control.SetAttributedTitle(title, UIControlState.Disabled);
        }
    }
}