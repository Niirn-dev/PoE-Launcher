using System;
using System.Globalization;
using System.Windows.Media;

namespace PoE_Launcher
{
    public class IsBusyToBackgroundConverter : BaseValueConverter<IsBusyToBackgroundConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value == true ? new SolidColorBrush(Color.FromRgb(0xfa, 0xfa, 0xcb)) : new SolidColorBrush(Color.FromRgb(0xef, 0xef, 0xef));

        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
