using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;
using XFStarter.Mobile.Core.Helpers;
using XFStarter.Mobile.Core.Logging;
using XFStarter.Mobile.Core.Services;

namespace XFStarter.Mobile.Core.L10N
{
    public interface ILocalizedStrings
    {
        string this[string key] { get; }
    }

    public class LocalizationManager : ObservableBase, ILocalizedStrings
    {
        private ILogger Logger = LoggerFactory.CreateLogger();
        public static LocalizationManager Instance { get; } = new LocalizationManager();
        public IResourceLocalizer ResourceLocalizer { get; set; }

        private CultureInfo currentCulture;
        public CultureInfo CurrentCulture
        {
            get { return currentCulture; }
            set
            {
                if(SetValue(ref currentCulture, value))
                {
                    UpdateCulture();
                }
            }
        }

        private WeakEventManager EventsManager { get; }

        public event EventHandler<CultureChangedEventArg> CultureChanged
        {
            add
            {
                EventsManager.AddEventHandler(nameof(CultureChanged), value);
            }
            remove
            {
                EventsManager.RemoveEventHandler(nameof(CultureChanged), value);
            }
        }

        public IList<CultureInfo> SupportedCultures { get; } = new List<CultureInfo>();

        public string this[string key] => ResourceLocalizer?.Localize(key);

        static LocalizationManager() { }
        private LocalizationManager()
        {
            EventsManager = WeakEventManager.GetWeakEventManager(this);

            try
            {
                Logger.Debug(Settings.CurrentCulture);

                CurrentCulture = new CultureInfo(Settings.CurrentCulture);
            }
            catch(Exception ex)
            {
                Logger.Error(ex);
                CurrentCulture = new CultureInfo("en-US");
            }
        }

        public void AddSupportedCultures(IEnumerable<CultureInfo> cultures)
        {
            foreach(var culture in cultures)
            {
                //log cultures, this will also force loading the properties for iOS bindings
                Logger.Debug($"Supported culture added - Name:{culture.Name}, EnglishName:{culture.EnglishName}, DisplayName:{culture.DisplayName}, NativeName:{culture.NativeName}");
                SupportedCultures.Add(culture);
            }
        }

        private void OnCultureChanged()
        {
            EventsManager.RaiseEvent(this, new CultureChangedEventArg(currentCulture), nameof(CultureChanged));

            // Update indexer bindings
            OnPropertyChanged("Item[]");
        }

        private void UpdateCulture()
        {
            Logger.TrackAnalytics(AnalyticsKeys.Culture.Updated, new Dictionary<string, string>
            {
                { "Name", CurrentCulture.Name },
                { "EnglishName", CurrentCulture.EnglishName },
                { "DisplayName", CurrentCulture.DisplayName },
                { "NativeName", CurrentCulture.NativeName }
            });

            CultureInfo.DefaultThreadCurrentCulture = CurrentCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CurrentCulture;
            ResourceLocalizer?.OnCultureUpdated?.Invoke(CurrentCulture);

            Settings.CurrentCulture = CurrentCulture.Name;

            var localeService = DependencyService.Get<ILocaleService>();
            localeService?.SetLocale(CurrentCulture);

            OnCultureChanged();
        }
    }
}
