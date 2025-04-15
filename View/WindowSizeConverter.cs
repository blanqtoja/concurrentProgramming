using System;
using System.Globalization;
using System.Windows.Data;
using ViewModel;

namespace View
{
    public class WindowSizeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length >= 2 &&
                values[0] is double width &&
                values[1] is double height)
            {
                return new WindowSize((int)width, (int)height);
            }

            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
