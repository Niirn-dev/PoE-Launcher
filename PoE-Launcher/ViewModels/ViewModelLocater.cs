using PoE_Launcher.Core;

namespace PoE_Launcher
{
    /// <summary>
    /// Locates view models from the IoC for use in binding in XAML files
    /// </summary>
    public class ViewModelLocater
    {
        #region Singleton

        /// <summary>
        /// Singleton instance of the locater
        /// </summary>
        public static ViewModelLocater Instance { get; private set; } = new ViewModelLocater();

        #endregion

        #region Public properties

        /// <summary>
        /// The application view model
        /// </summary>
        public static ApplicationViewModel ApplicationVM => IoC.Get<ApplicationViewModel>();

        #endregion
    }
}
