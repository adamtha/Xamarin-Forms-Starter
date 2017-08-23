using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Settings.Abstractions;
namespace XFStarter.Mobile.Core.Helpers
{
    public class DebugSettings : ISettings
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

        #region ISettings
        public decimal GetValueOrDefault(string key, decimal defaultValue, string fileName = null)
        {
            return GetValueOrDefault(key, defaultValue);
        }

        public bool GetValueOrDefault(string key, bool defaultValue, string fileName = null)
        {
            return GetValueOrDefault(key, defaultValue);
        }

        public long GetValueOrDefault(string key, long defaultValue, string fileName = null)
        {
            return GetValueOrDefault(key, defaultValue);
        }

        public string GetValueOrDefault(string key, string defaultValue, string fileName = null)
        {
            return GetValueOrDefault(key, defaultValue);
        }

        public int GetValueOrDefault(string key, int defaultValue, string fileName = null)
        {
            return GetValueOrDefault(key, defaultValue);
        }

        public float GetValueOrDefault(string key, float defaultValue, string fileName = null)
        {
            return GetValueOrDefault(key, defaultValue);
        }

        public DateTime GetValueOrDefault(string key, DateTime defaultValue, string fileName = null)
        {
            return GetValueOrDefault(key, defaultValue);
        }

        public Guid GetValueOrDefault(string key, Guid defaultValue, string fileName = null)
        {
            return GetValueOrDefault(key, defaultValue);
        }

        public double GetValueOrDefault(string key, double defaultValue, string fileName = null)
        {
            return GetValueOrDefault(key, defaultValue);
        }

        public bool AddOrUpdateValue(string key, decimal value, string fileName = null)
        {
            return AddOrUpdateValue(key, value);
        }

        public bool AddOrUpdateValue(string key, bool value, string fileName = null)
        {
            return AddOrUpdateValue(key, value);
        }

        public bool AddOrUpdateValue(string key, long value, string fileName = null)
        {
            return AddOrUpdateValue(key, value);
        }

        public bool AddOrUpdateValue(string key, string value, string fileName = null)
        {
            return AddOrUpdateValue(key, value);
        }

        public bool AddOrUpdateValue(string key, int value, string fileName = null)
        {
            return AddOrUpdateValue(key, value);
        }

        public bool AddOrUpdateValue(string key, float value, string fileName = null)
        {
            return AddOrUpdateValue(key, value);
        }

        public bool AddOrUpdateValue(string key, DateTime value, string fileName = null)
        {
            return AddOrUpdateValue(key, value);
        }

        public bool AddOrUpdateValue(string key, Guid value, string fileName = null)
        {
            return AddOrUpdateValue(key, value);
        }

        public bool AddOrUpdateValue(string key, double value, string fileName = null)
        {
            return AddOrUpdateValue(key, value);
        }

        public void Remove(string key, string fileName = null)
        {
            lock(objLock)
            {
                data.Remove(key);
            }
        }

        public void Clear(string fileName = null)
        {
            lock(objLock)
            {
                data.Clear();
            }
        }

        public bool Contains(string key, string fileName = null)
        {
            lock(objLock)
            {
                return data.ContainsKey(key);
            }
        }
        #endregion
    }
}