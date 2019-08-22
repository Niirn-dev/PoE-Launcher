using PoE_Launcher.Core;
using System.Windows;

namespace PoE_Launcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Custom start up so we can load out IoC immediately before anything else
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            // Let the base application do what it needs
            base.OnStartup(e);

            // Setup IoC
            IoC.Setup();

            // Show the MainWindow
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }
    }
}
