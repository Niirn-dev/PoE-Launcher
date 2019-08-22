using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PoE_Launcher
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
            OpenExplorerCommand = new RelayCommand(async () => await OpenExplorer());

            // Create events for properties
            OnPropertyChanged(nameof(IsBusyProperty));
        }

        #endregion

        #region Tasks

        /// <summary>
        /// Opens the file explorer to find the required file
        /// </summary>
        /// <returns></returns>
        private async Task OpenExplorer()
        {
            await this.RunCommand(
                () => this.IsCommandRunning, 
                async () => 
                {
                    // Placeholder for the action to be performed here
                    await Task.Delay(500);
                }
            );
        }

        #endregion
    }
}
