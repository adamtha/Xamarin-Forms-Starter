using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using UIKit;
using Xamarin.Forms;
using XFStarter.Mobile.Core.Services;
using XFStarter.Mobile.Core.iOS.Services;

[assembly: Dependency(typeof(ToastNotifier))]

namespace XFStarter.Mobile.Core.iOS.Services
{
    public class ToastNotifier : IToastNotifier
    {
        public Task<bool> Notify(ToastNotificationType type, string title, string description, int millisecondsDelay = 500)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();
            ProgressHUD.Shared.ShowToast(description, false, millisecondsDelay);
            return taskCompletionSource.Task;
        }
    }
}