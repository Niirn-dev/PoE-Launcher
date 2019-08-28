using System;
using System.Windows.Input;

namespace PoE_Launcher.Core
{
    public class FileExplorerPageViewModel : BaseViewModel
    {
        #region Private properties

        #endregion

        #region Public properties

        #endregion

        #region Commands

        public ICommand OpenMainPageCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public FileExplorerPageViewModel()
        {
            OpenMainPageCommand = new RelayCommand(() => OpenMainPage());
        }

        #endregion

        #region Command Implementations

        private void OpenMainPage()
        {
            // Go to the main page
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Main);
        }

        #endregion
    }
}
