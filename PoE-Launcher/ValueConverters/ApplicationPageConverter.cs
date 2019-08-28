using PoE_Launcher.Core;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace PoE_Launcher
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to a WPF page
    /// </summary>
    [ValueConversion(typeof(ApplicationPage), typeof(Page))]
    public class ApplicationPageConverter : BaseValueConverter<ApplicationPageConverter>
    {
        public static ApplicationPageConverter Instance => new ApplicationPageConverter();

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Find the appropriate page
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Main:
                    return new MainPage();

                case ApplicationPage.Explorer:
                    return new FileExplorerPage();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
