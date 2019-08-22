using System;
using System.Windows.Input;

namespace PoE_Launcher
{
    /// <summary>
    /// View model for each macro list item
    /// </summary>
    public class MacroListItemViewModel : BaseViewModel
    {
        #region Public properties

        /// <summary>
        /// Name of the macro
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Full path to the macro file
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// Flag that indicated, whether the macro should be launched or not
        /// </summary>
        public bool IsEnabled { get; set; }

        #endregion

        #region Commands

        public ICommand OpenExplorerCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MacroListItemViewModel()
        {
            OpenExplorerCommand = new RelayCommand(() => { OpenExplorer(); });
        }

        #endregion

        #region Tasks

        /// <summary>
        /// Task to open a file explorer window
        /// </summary>
        private void OpenExplorer()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
