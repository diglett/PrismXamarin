using Prism.Navigation;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace PrismUnityAppBase.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly Dictionary<string, object> _propertyValueMap;

        protected ViewModelBase()
        {
            _propertyValueMap = new Dictionary<string, object>();
        }

        private void InternalPropertyUpdate(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> path)
        {
            var propertyName = GetPropertyName(path);
            InternalPropertyUpdate(propertyName);
        }

        protected T Get<T>(Expression<Func<T>> path)
        {
            return Get(path, default(T));
        }

        protected virtual T Get<T>(Expression<Func<T>> path, T defaultValue)
        {
            var propertyName = GetPropertyName(path);
            if (_propertyValueMap.ContainsKey(propertyName))
            {
                return (T)_propertyValueMap[propertyName];
            }
            else
            {
                try
                {
                    _propertyValueMap.Add(propertyName, defaultValue);
                }
                catch
                {
                }
                
                return defaultValue;
            }
        }

        protected virtual void Set<T>(Expression<Func<T>> path, T value)
        {
            Set(path, value, false);
        }

        protected virtual void Set<T>(Expression<Func<T>> path, T value, bool forceUpdate)
        {
            var oldValue = Get(path);
            var propertyName = GetPropertyName(path);

            if (!Equals(value, oldValue) || forceUpdate)
            {
                _propertyValueMap[propertyName] = value;
                OnPropertyChanged(path);
            }
        }

        protected static string GetPropertyName<T>(Expression<Func<T>> expression)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            var body = expression.Body;
            var memberExpression = body as MemberExpression;
            if (memberExpression == null)
            {
                memberExpression = (MemberExpression)((UnaryExpression)body).Operand;
            }
            return memberExpression.Member.Name;
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {

        }
    }
}