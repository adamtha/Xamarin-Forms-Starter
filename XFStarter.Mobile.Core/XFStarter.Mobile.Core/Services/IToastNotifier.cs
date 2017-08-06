using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFStarter.Mobile.Core.Services
{
    public enum ToastMaskType
    {
        None = 1,
        Clear,
        Black,
        Gradient
    }

    public enum ToastNotificationType
    {
        Info,
        Success,
        Error,
        Warning,
    }

    public interface IToastNotifier
    {
        void Show(string status = null, float progress = -1, ToastMaskType maskType = ToastMaskType.None);

        void ShowSuccessWithStatus(string status, double timeoutMs = 1000);

        void ShowErrorWithStatus(string status, double timeoutMs = 1000);

        Task<bool> Notify(ToastNotificationType type, string title, string description, int millisecondsDelay = 500);
    }

    public static class IToastNotifierExtentions
    {
        public static void ToToast(this string message, ToastNotificationType type = ToastNotificationType.Info, string title = null, int millisecondsDelay = 500)
        {
            Device.BeginInvokeOnMainThread(() => {
                var toaster = DependencyService.Get<IToastNotifier>();
                toaster?.Notify(type, title ?? type.ToString().ToUpper(), message, millisecondsDelay);
            });
        }
    }
}
