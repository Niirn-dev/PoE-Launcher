using PoE_Launcher.Core;
using System;
using System.Diagnostics;
using System.Globalization;

namespace PoE_Launcher
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to an actual view/page
    /// </summary>
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
