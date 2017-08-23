using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFStarter.Mobile.Core.Behaviors
{
    public class EntryLengthValidatorBehavior : BehaviorBase<Entry>
    {
        public int MaxLength { get; set; }

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

            if(string.IsNullOrWhiteSpace(entry.Text))
            {
                return;
            }

            if(entry.Text.Length <= MaxLength)
            {
                return;
            }

            entry.Text = args.OldTextValue;
        }
    }
}
