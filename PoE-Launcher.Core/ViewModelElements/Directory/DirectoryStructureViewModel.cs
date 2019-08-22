using System.Collections.ObjectModel;
using System.Linq;

namespace PoE_Launcher.Core
{
    /// <summary>
    /// The view model for the application main DIrectory view
    /// </summary>
    public class DirectoryStructureViewModel : BaseViewModel
    {
        #region Public properties
        /// <summary>
        /// A list of all directories on the machine
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public DirectoryStructureViewModel()
        {
            // Create new view models for each drive
            this.Items = new ObservableCollection<DirectoryItemViewModel>(
                    DirectoryStructure.GetLogicalDrives().Select(drive => new DirectoryItemViewModel(drive.FullPath, DirectoryItemType.Drive))
                );
        }

        #endregion
    }
}
