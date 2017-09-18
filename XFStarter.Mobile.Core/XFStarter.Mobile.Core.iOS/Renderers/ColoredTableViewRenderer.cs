using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFStarter.Mobile.Core.iOS.Renderers;
using XFStarter.Mobile.Core.UserControls;

[assembly: ExportRenderer(typeof(ColoredTableView), typeof(ColoredTableViewRenderer))]

namespace XFStarter.Mobile.Core.iOS.Renderers
{
    public class ColoredTableViewRenderer : TableViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<TableView> e)
        {
            base.OnElementChanged(e);
            if(Control == null)
                return;

            var tableView = Control as UITableView;
            var coloredTableView = Element as ColoredTableView;
            tableView.WeakDelegate = new CustomHeaderTableModelRenderer(coloredTableView);
        }

        private class CustomHeaderTableModelRenderer : UnEvenTableViewModelRenderer
        {
            private readonly ColoredTableView _coloredTableView;
            public CustomHeaderTableModelRenderer(TableView model) : base(model)
            {
                _coloredTableView = model as ColoredTableView;
            }

            private UITextAlignment ToUITextAlignment(TextAlignment textAlignment)
            {
                switch(textAlignment)
                {
                    case TextAlignment.Center: return UITextAlignment.Center;
                    case TextAlignment.End: return UITextAlignment.Right;
                    case TextAlignment.Start:
                    default:
                        return UITextAlignment.Left;
                }
            }

            public override UIView GetViewForHeader(UITableView tableView, nint section)
            {
                return new UILabel()
                {
                    Text = TitleForHeader(tableView, section),
                    TextColor = _coloredTableView.TextColor.ToUIColor(),
                    TextAlignment = ToUITextAlignment(_coloredTableView.TextAlignment)
                };
            }
        }
    }
}