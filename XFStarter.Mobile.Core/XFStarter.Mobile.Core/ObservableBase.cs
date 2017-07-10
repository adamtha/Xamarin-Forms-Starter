using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace XFStarter.Mobile.Core
{
    /// <summary>
    /// This base class supports property notification in a fluid and easy API
    ///
    /// private string propertyName;
    /// public string PropertyName
    /// {
    ///     get { return propertyName; }
    ///     set { SetValue(ref propertyName, value); }
    /// }
    ///
    /// Multiple notifications:
    ///
    /// private string propertyName;
    /// public string PropertyName
    /// {
    ///     get { return propertyName; }
    ///     set
    ///     {
    ///         if(SetValue(ref propertyName, value))
    ///         {
    ///             OnPropertyChanged(nameof(OtherPropertyName1));
    ///             OnPropertyChanged(nameof(OtherPropertyName2));
    ///         }
    ///     }
    /// </summary>
    public class ObservableBase : INotifyPropertyChanged, IDisposable
    {
        protected bool SetValue<T>(ref T property, T value, [CallerMemberName]string propertyName = null)
        {
            if(Equals(property, value))
            {
                return false;
            }

            property = value;
            OnPropertyChangedExplicit(propertyName);
            return true;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            OnPropertyChangedExplicit(propertyName);
        }

        protected void OnPropertyChanged<T>(Expression<Func<T>> projection)
        {
            var name = (projection?.Body as MemberExpression)?.Member?.Name;
            if(string.IsNullOrEmpty(name))
            {
                return;
            }

            OnPropertyChangedExplicit(name);
        }

        protected void OnPropertiesChanged()
        {
            OnPropertyChangedExplicit("");
        }

        private void OnPropertyChangedExplicit(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            PropertyChanged = null;
        }
        #endregion
    }
}
