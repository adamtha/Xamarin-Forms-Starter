// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace XFStarter.Mobile.Core.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        public static ISettings AppSettings
        {
            get
            {
                if(CrossSettings.IsSupported)
                {
                    return CrossSettings.Current;
                }
                return new DebugSettings();
            }
        }

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;

        #endregion

        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }

        #region CurrentCulture
        private const string CurrentCultureKey = nameof(CurrentCultureKey);
        private static readonly string CurrentCultureDefault = "en-US";

        public static string CurrentCulture
        {
            get { return AppSettings.GetValueOrDefault(CurrentCultureKey, CurrentCultureDefault); }
            set { AppSettings.AddOrUpdateValue(CurrentCultureKey, value); }
        }
        #endregion
    }
}