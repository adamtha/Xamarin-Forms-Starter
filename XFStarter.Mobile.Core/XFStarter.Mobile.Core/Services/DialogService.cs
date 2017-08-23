using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFStarter.Mobile.Core.Services;

[assembly: Xamarin.Forms.Dependency(typeof(DialogService))]

namespace XFStarter.Mobile.Core.Services
{
    public class DialogService : IDialogService
    {
        private static NavigationPage navigationPage { get { return Application.Current.MainPage as NavigationPage; } }
        private static INavigation navigation { get { return navigationPage.Navigation; } }

        public Task DisplayAlertAsync(string title, string message, string cancel)
        {
            return navigationPage.CurrentPage.DisplayAlert(title, message, cancel);
        }

        public async Task<bool> DisplayAlertAsync(string title, string message, string accept, string cancel)
        {
            return await navigationPage.CurrentPage.DisplayAlert(title, message, accept, cancel);
        }

        public async Task<string> DisplayActionSheetAsync(string title, string cancel, string destruction, params string[] buttons)
        {
            return await navigationPage.CurrentPage.DisplayActionSheet(title, cancel, destruction, buttons);
        }

        public Task PushAsync(Page page, bool animated = false)
        {
            return navigation.PushAsync(page, animated);
        }

        public Task PushModalAsync(Page page, bool animated = false)
        {
            return navigation.PushModalAsync(page, animated);
        }

        public async Task<Page> PopAsync(bool animated = false)
        {
            if(navigation.NavigationStack.Count < 1)
            {
                return null;
            }

            return await navigation.PopAsync(animated);
        }

        public async Task<Page> PopModalAsync(bool animated = false)
        {
            if(navigation.ModalStack.Count < 1)
            {
                return null;
            }

            return await navigation.PopModalAsync(animated);
        }

        public Task PopToRootAsync(bool animated = false)
        {
            return navigation.PopToRootAsync(animated);
        }

        public void RemovePage(Page page)
        {
            if(!navigation.NavigationStack.Contains(page))
            {
                return;
            }

            navigation.RemovePage(page);
        }
    }
}
