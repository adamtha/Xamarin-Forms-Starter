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
		private static ISettings AppSettings
		{
			get
			{
                // if not supported, fallback to debug mode
                ISettings settings = new DebugSettings();
                try
                {
                    settings = CrossSettings.Current;
                }
                catch { }

                return settings;
            }
		}

        private const string SettingsKey = nameof(SettingsKey);
        private static readonly string SettingsDefault = string.Empty;

        public static string GeneralSettings
        {
            get { return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault); }
            set { AppSettings.AddOrUpdateValue(SettingsKey, value); }
        }

        private const string ShowTutorialKey = nameof(ShowTutorialKey);
        private static readonly bool ShowTutorialDefault = false;

        public static bool ShowTutorial
        {
            get { return AppSettings.GetValueOrDefault(ShowTutorialKey, ShowTutorialDefault); }
            set { AppSettings.AddOrUpdateValue(ShowTutorialKey, value); }
        }
    }
}