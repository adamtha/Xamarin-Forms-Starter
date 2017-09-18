using System;
using Android.Content;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFStarter.Mobile.Core.Android.Renderers;
using XFStarter.Mobile.Core.UserControls;

[assembly: ExportRenderer(typeof(TableView), typeof(ColoredTableViewRenderer))]

namespace XFStarter.Mobile.Core.Android.Renderers
{
    public class ColoredTableViewRenderer : TableViewRenderer
    {
        protected override TableViewModelRenderer GetModelRenderer(global::Android.Widget.ListView listView, TableView view)
        {
            return new CustomHeaderTableViewModelRenderer(Context, listView, view);
        }

        private class CustomHeaderTableViewModelRenderer : TableViewModelRenderer
        {
            private readonly ColoredTableView _coloredTableView;

            public CustomHeaderTableViewModelRenderer(Context context, global::Android.Widget.ListView listView, TableView view) : base(context, listView, view)
            {
                _coloredTableView = view as ColoredTableView;
            }

            private global::Android.Views.TextAlignment ToAndroidTextAlignment(Xamarin.Forms.TextAlignment textAlignment)
            {
                switch(textAlignment)
                {
                    case Xamarin.Forms.TextAlignment.Center: return global::Android.Views.TextAlignment.Center;
                    case Xamarin.Forms.TextAlignment.End: return global::Android.Views.TextAlignment.TextEnd;
                    case Xamarin.Forms.TextAlignment.Start:
                    default:
                        return global::Android.Views.TextAlignment.TextStart;
                }
            }

            public override global::Android.Views.View GetView(int position, global::Android.Views.View convertView, ViewGroup parent)
            {
                var view = base.GetView(position, convertView, parent);

                var element = GetCellForPosition(position);

                // section header will be a TextCell
                if(element.GetType() == typeof(TextCell))
                {
                    try
                    {
                        // Get the textView of the actual layout
                        var textView = ((((view as LinearLayout).GetChildAt(0) as LinearLayout).GetChildAt(1) as LinearLayout).GetChildAt(0) as TextView);

                        // get the divider below the header
                        var divider = (view as LinearLayout).GetChildAt(1);

                        // Set the color
                        textView.SetTextColor(_coloredTableView.TextColor.ToAndroid());
                        textView.TextAlignment = ToAndroidTextAlignment(_coloredTableView.TextAlignment);
                        divider.SetBackgroundColor(_coloredTableView.TextColor.ToAndroid());
                    }
                    catch(Exception) { }
                }

                return view;
            }
        }
    }
}