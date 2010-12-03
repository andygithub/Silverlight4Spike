namespace Caliburn.Silverlight.ApplicationFramework.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;

    public class AccountTypeToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var realValue = (int)value;

            if (realValue== -10) return new SolidColorBrush(Colors.Red);
            if (realValue== 1) return new SolidColorBrush(Colors.Yellow);
            if (realValue == 10) return new SolidColorBrush(Colors.Green);

            return new SolidColorBrush(Colors.Black);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}