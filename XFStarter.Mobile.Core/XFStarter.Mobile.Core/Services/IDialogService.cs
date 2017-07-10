using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFStarter.Mobile.Core.Services
{
    public interface IDialogService
    {
        Task DisplayAlertAsync(string title, string message, string cancel);
        Task<bool> DisplayAlertAsync(string title, string message, string accept, string cancel);
        Task<string> DisplayActionSheetAsync(string title, string cancel, string destruction, params string[] buttons);

        Task PushAsync(Page page, bool animated = false);
        Task PushModalAsync(Page page, bool animated = false);
        Task<Page> PopAsync(bool animated = false);
        Task<Page> PopModalAsync(bool animated = false);
        Task PopToRootAsync(bool animated = false);

        void RemovePage(Page page);
    }
}
