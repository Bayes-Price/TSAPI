using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TSAPI.ApiBrowser
{
	public sealed class MainConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string p = (string)parameter;
			if (p == "SomeVisible")
			{
				return value == null ? Visibility.Hidden : Visibility.Visible;
			}
			if (p == "SomeTrue")
			{
				return value != null;
			}
			if (p == "NoneTrue")
			{
				return value == null;
			}
			throw new NotImplementedException();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
