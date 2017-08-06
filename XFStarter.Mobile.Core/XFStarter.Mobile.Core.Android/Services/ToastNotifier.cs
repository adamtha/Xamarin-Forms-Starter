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
using AndroidHUD;
using Xamarin.Forms;
using XFStarter.Mobile.Core.Android.Services;
using XFStarter.Mobile.Core.Services;

[assembly: Dependency(typeof(ToastNotifier))]

namespace XFStarter.Mobile.Core.Android.Services
{
    static class ToastMaskTypeExtentions
    {
        public static AndroidHUD.MaskType ToProgressHUDMaskType(this ToastMaskType maskType)
        {
            switch(maskType)
            {
                case ToastMaskType.Clear: return MaskType.Clear;
                case ToastMaskType.Black: return MaskType.Black;
                case ToastMaskType.Gradient: return MaskType.Black;
                case ToastMaskType.None:
                default: return MaskType.None;
            }
        }
    }

    public class ToastNotifier : IToastNotifier
    {
        public static Context Context { get; set; }

        public void Show(string status = null, float progress = -1F, ToastMaskType maskType = ToastMaskType.Clear)
        {
            AndHUD.Shared.Show(Context, status, -1, MaskType.Clear);
        }

        public void ShowSuccessWithStatus(string status, double millisecondsDelay = 1000)
        {
            AndHUD.Shared.ShowSuccess(Context, status, MaskType.Clear, TimeSpan.FromMilliseconds(millisecondsDelay));
        }

        public void ShowErrorWithStatus(string status, double millisecondsDelay = 1000)
        {
            AndHUD.Shared.ShowError(Context, status, MaskType.Clear, TimeSpan.FromMilliseconds(millisecondsDelay));
        }

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