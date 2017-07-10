using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFStarter.Mobile.Core.Services
{
    public interface IToastNotifier
    {
        Task<bool> Notify(ToastNotificationType type, string title, string description, int millisecondsDelay = 500);
    }

    public enum ToastNotificationType
    {
        Info,
        Success,
        Error,
        Warning,
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
