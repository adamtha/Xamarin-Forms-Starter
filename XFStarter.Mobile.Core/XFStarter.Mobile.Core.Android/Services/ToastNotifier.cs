using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using XFStarter.Mobile.Core.Android.Services;
using XFStarter.Mobile.Core.Services;

[assembly: Dependency(typeof(ToastNotifier))]

namespace XFStarter.Mobile.Core.Android.Services
{
    public class ToastNotifier : IToastNotifier
    {
        public Task<bool> Notify(ToastNotificationType type, string title, string description, int millisecondsDelay = 500)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();
            var toast = Toast.MakeText(Forms.Context, description, ToastLength.Short);
            toast.Show();

            if(millisecondsDelay > 0)
            {
                Task.Delay(millisecondsDelay).ContinueWith(t =>
                {
                    try
                    {
                        toast.Cancel();
                    }
                    catch { }
                }).ConfigureAwait(false);
            }

            return taskCompletionSource.Task;
        }
    }
}