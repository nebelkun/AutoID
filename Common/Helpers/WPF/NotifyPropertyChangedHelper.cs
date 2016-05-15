using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Common.Helpers.WPF
{
	public class NotifyPropertyChangedHelper
	{
		PropertyChangedEventHandler _propertyChangeHandler;

		public void Add(PropertyChangedEventHandler value)
		{
			_propertyChangeHandler += value;
		}

		public void Remove(PropertyChangedEventHandler value)
		{
			if (_propertyChangeHandler != null) _propertyChangeHandler -= value;
		}

		public void NotifyPropertyChanged(object sender, string propertyName)
		{
			_propertyChangeHandler?.Invoke(sender, new PropertyChangedEventArgs(propertyName));
		}

		public void SetValue<T>(object containingObject, ref T field, T value, params string[] names)
		{
			if (names == null) throw new ArgumentNullException(nameof(names));

			if (!EqualityComparer<T>.Default.Equals(field, value))
			{
				field = value;
				foreach (string t in names)
				{
					NotifyPropertyChanged(containingObject, t);
				}
			}
		}
	}
}