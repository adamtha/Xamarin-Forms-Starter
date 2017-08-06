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
    static class ToastMaskTypeExtentions
    {
        public static ProgressHUD.MaskType ToProgressHUDMaskType(this ToastMaskType maskType)
        {
            switch(maskType)
            {
                case ToastMaskType.Clear: return ProgressHUD.MaskType.Clear;
                case ToastMaskType.Black: return ProgressHUD.MaskType.Black;
                case ToastMaskType.Gradient: return ProgressHUD.MaskType.Gradient;
                case ToastMaskType.None:
                default: return ProgressHUD.MaskType.None;
            }
        }
    }

    public class ToastNotifier : IToastNotifier
    {
        public void Show(string status = null, float progress = -1, ToastMaskType maskType = ToastMaskType.Clear)
        {
            ProgressHUD.Shared.Show(status, progress, maskType.ToProgressHUDMaskType());
        }

        public void Show(string cancelCaption, Action cancelCallback, string status = null, float progress = -1, ToastMaskType maskType = ToastMaskType.Clear)
        {
            ProgressHUD.Shared.Show(cancelCaption, cancelCallback, status, progress, maskType.ToProgressHUDMaskType());
        }

        public void ShowContinuousProgress(string status = null, ToastMaskType maskType = ToastMaskType.Clear)
        {
            ProgressHUD.Shared.ShowContinuousProgress(status, maskType.ToProgressHUDMaskType());
        }

        public void ShowSuccessWithStatus(string status, double millisecondsDelay = 1000)
        {
            ProgressHUD.Shared.ShowSuccessWithStatus(status, millisecondsDelay);
        }

        public void ShowErrorWithStatus(string status, double millisecondsDelay = 1000)
        {
            ProgressHUD.Shared.ShowErrorWithStatus(status, millisecondsDelay);
        }

        public Task<bool> Notify(ToastNotificationType type, string title, string description, int millisecondsDelay = 500)
        {
            ProgressHUD.Shared.ShowToast(description, false, millisecondsDelay);
            return Task.FromResult(true);
        }
    }
}