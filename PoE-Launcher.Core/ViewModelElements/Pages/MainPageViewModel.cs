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
        public ICommand OpenExplorerCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainPageViewModel()
        {
            // Create commands
            OpenExplorerCommand = new RelayCommand(async () => await OpenExplorerAsync());
        }

        #endregion

        #region Tasks

        /// <summary>
        /// Opens the file explorer to find the required file
        /// </summary>
        /// <returns></returns>
        private async Task OpenExplorerAsync()
        {
            // TO FIX: Doesn't wait for the page closing animation and instantly proceeds to animate new page in
            // Go to the directory explorer page
            await Task.Run(() => IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Explorer);
        }

        #endregion
    }
}
