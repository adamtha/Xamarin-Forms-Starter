using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFStarter.Mobile.Core.Services
{
    public enum Platform
    {
        Unknown,
        Android,
        iOS,
        WindowsPhone
    }

    public interface IDeviceInfo
    {
        /// <summary>
        /// This is the device specific Id (remember the correct permissions in your app to use this)
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Get the model of the device
        /// </summary>
        string Model { get; }

        /// <summary>
        /// Get the version of the Operating System
        /// </summary>
        string Version { get; }

        /// <summary>
        /// Get the platform of the device
        /// </summary>
        Platform Platform { get; }
    }
}
