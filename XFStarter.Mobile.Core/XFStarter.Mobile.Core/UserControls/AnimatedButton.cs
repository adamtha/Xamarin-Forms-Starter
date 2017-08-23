using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFStarter.Mobile.Core.UserControls
{
    public class AnimatedButton : Button
    {
        public AnimatedButton() : base()
        {
            const int _animationTime = 100;
            Clicked += async (sender, e) =>
            {
                try
                {
                    var btn = sender as AnimatedButton;
                    if(btn.AnimationIsRunning("ScaleTo"))
                    {
                        return;
                    }

                    await btn.ScaleTo(1.2, _animationTime);
                    btn.ScaleTo(1, _animationTime);
                }
                catch { }
            };
        }
    }
}
