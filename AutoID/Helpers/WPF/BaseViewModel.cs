using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoID.Helpers.WPF
{
	public abstract class BaseViewModel : INotifyPropertyChanged
	{
		#region INotifyPropertyChanged Members and helper

		readonly NotifyPropertyChangedHelper _propertyChangeHelper = new NotifyPropertyChangedHelper();

		public event PropertyChangedEventHandler PropertyChanged
		{
			add { _propertyChangeHelper.Add(value); }
			remove { _propertyChangeHelper.Remove(value); }
		}

		protected void OnPropertyChanged(string propertyName)
		{
			_propertyChangeHelper.NotifyPropertyChanged(this, propertyName);
		}

		protected void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
		{
			OnPropertyChanged(ExtractPropertyName(propertyExpression));
		}

		static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
		{
			if (propertyExpression == null)
				throw new ArgumentNullException(nameof(propertyExpression));
			var memberExpression = propertyExpression.Body as MemberExpression;
			if (memberExpression == null)
				throw new ArgumentException("The expression is not a member access expression.", nameof(propertyExpression));
			var property = memberExpression.Member as PropertyInfo;
			if (property == null)
				throw new ArgumentException("The member access expression does not access a property.", nameof(propertyExpression));
			return property.Name;
		}

		#endregion
	}
}