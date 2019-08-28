using PoE_Launcher.Core;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace PoE_Launcher
{
    [ValueConversion(typeof(DirectoryItemType), typeof(BitmapImage))]
    public class ItemTypeToImageConverter : BaseValueConverter<ItemTypeToImageConverter>
    {
        public static ItemTypeToImageConverter Instance = new ItemTypeToImageConverter();

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string image;

            switch ((DirectoryItemType)value)
            {
                case DirectoryItemType.Drive:
                    image = "Images/Directory/drive.png";
                    break;
                case DirectoryItemType.Folder:
                    image = "Images/Directory/folder.png";
                    break;
                default:
                    // By default we presume item is file
                    image = "Images/Directory/file.png";
                    break;
            }

            // return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
            // Remade Universal link to a relative one to fix the WPF designer issue
            return new BitmapImage(new Uri($"/{image}", UriKind.Relative));
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
