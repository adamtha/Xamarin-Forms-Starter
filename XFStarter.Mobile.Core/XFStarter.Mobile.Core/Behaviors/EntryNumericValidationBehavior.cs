using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFStarter.Mobile.Core.Behaviors
{
    public class EntryNumericValidationBehavior : BehaviorBase<Entry>
    {
        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);
            (bindable as Entry).TextChanged += OnEntryTextChanged;
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            (bindable as Entry).TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(bindable);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            var entry = sender as Entry;

            int result;
            var isValid = int.TryParse(args.NewTextValue, out result);

            entry.TextColor = isValid ? Color.Default : Color.Red;
        }
    }
}
