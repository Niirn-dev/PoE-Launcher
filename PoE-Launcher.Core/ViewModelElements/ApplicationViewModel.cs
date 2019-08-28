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
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Main;

        /// <summary>
        /// Navigates to the specified page
        /// </summary>
        /// <param name="page">The <see cref="ApplicationPage"/> to go to</param>
        public void GoToPage(ApplicationPage page)
        {
            // Change the current page
            CurrentPage = page;
        }
    }
}
