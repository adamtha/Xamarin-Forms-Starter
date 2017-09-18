using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFStarter.Mobile.Core.UserControls
{
    public class ColoredTableView : TableView
    {
        public static BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(ColoredTableView), Color.Black);
        public Color TextColor
        {
            get
            {
                return (Color)GetValue(TextColorProperty);
            }
            set
            {
                SetValue(TextColorProperty, value);
            }
        }

        public static BindableProperty TextAlignmentProperty = BindableProperty.Create(nameof(TextAlignment), typeof(TextAlignment), typeof(ColoredTableView), TextAlignment.Start);
        public TextAlignment TextAlignment
        {
            get
            {
                return (TextAlignment)GetValue(TextAlignmentProperty);
            }
            set
            {
                SetValue(TextAlignmentProperty, value);
            }
        }

        public ColoredTableView() : base() { }
    }
}
