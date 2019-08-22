namespace PoE_Launcher.Core
{
    /// <summary>
    /// The application state as a view model
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        /// <summary>
        /// Current page to be displayed in the main window
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Main;
    }
}
