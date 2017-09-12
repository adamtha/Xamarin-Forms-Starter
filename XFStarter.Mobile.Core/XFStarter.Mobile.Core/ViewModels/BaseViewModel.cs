using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFStarter.Mobile.Core.L10N;

namespace XFStarter.Mobile.Core.ViewModels
{
    public class BaseViewModel : ObservableBase
    {
        protected bool IsActive { get; set; } = false;

        private ICommand appearingCommand;
        public ICommand AppearingCommand
        {
            get
            {
                return appearingCommand ?? (appearingCommand = new Command(() =>
                {
                    IsActive = true;
                    // refresh all properties
                    OnPropertiesChanged();
                    OnAppearing();
                }));
            }
        }

        protected virtual void OnAppearing() { }

        private ICommand disappearingCommand;
        public ICommand DisappearingCommand
        {
            get
            {
                return disappearingCommand ?? (disappearingCommand = new Command(() =>
                {
                    IsActive = false;
                    OnDisappearing();
                }));
            }
        }

        protected virtual void OnDisappearing() { }

        public ILocalizedStrings LocalizedStrings => LocalizationManager.Instance;
    }
}
