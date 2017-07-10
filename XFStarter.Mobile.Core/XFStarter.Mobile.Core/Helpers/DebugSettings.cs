using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Settings.Abstractions;
namespace XFStarter.Mobile.Core.Helpers
{
    internal class DebugSettings : ISettings
    {
        private readonly object objLock = new object();
        private static readonly Dictionary<string, object> data = new Dictionary<string, object>();

        public bool AddOrUpdateValue<T>(string key, T value)
        {
            lock(objLock)
            {
                data[key] = value;
            }
            return true;
        }

        public void Clear()
        {
            lock(objLock)
            {
                data.Clear();
            }
        }

        public bool Contains(string key)
        {
            lock(objLock)
            {
                return data.ContainsKey(key);
            }
        }

        public T GetValueOrDefault<T>(string key, T defaultValue = default(T))
        {
            lock(objLock)
            {
                object value;
                if(data.TryGetValue(key, out value))
                {
                    return (T)value;
                }
            }
            return defaultValue;
        }

        public void Remove(string key)
        {
            lock(objLock)
            {
                data.Remove(key);
            }
        }
    }
}