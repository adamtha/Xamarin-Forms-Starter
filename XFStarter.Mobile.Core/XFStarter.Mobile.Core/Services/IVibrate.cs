using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFStarter.Mobile.Core.Services
{
    public interface IVibrate
    {
        void Vibration(int milliseconds = 500);
    }
}
