using System;
using System.Globalization;
using System.Windows.Data;

namespace View
{
    public class CenterPositionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2 && values[0] is double centerPosition && values[1] is double radius)
            {
                return centerPosition - radius;
            }
            return 0.0;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}