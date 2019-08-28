using System.Threading.Tasks;
using System.Windows.Input;

namespace PoE_Launcher.Core
{
    /// <summary>
    /// View model for the main screen
    /// </summary>
    public class MainPageViewModel : BaseViewModel
    {
        #region Private properties



        #endregion

        #region Public properties

        /// <summary>
        /// A full path to the PoE executable
        /// </summary>
        public string ExecutableFullPath { get; set; }

        /// <summary>
        /// A flag to indicate whether the command is running or not
        /// </summary>
        public bool IsCommandRunning { get; set; } = false;

        #endregion

        #region Commands

        /// <summary>
        /// The command to show the system menu of the window
        /// </summary>
        public ICommand OpenExplorerPageCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainPageViewModel()
        {
            // Create commands
            OpenExplorerPageCommand = new RelayCommand(() => OpenExplorerPage());
        }

        #endregion

        #region Command Implementations

        /// <summary>
        /// Opens the file explorer to find the required file
        /// </summary>
        /// <returns></returns>
        private void OpenExplorerPage()
        {
            // Go to the directory explorer page
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Explorer);
        }

        #endregion
    }
}
