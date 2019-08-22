using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PoE_Launcher.Core
{
    /// <summary>
    /// View model for each directory item
    /// </summary>
    public class DirectoryItemViewModel : BaseViewModel
    {
        #region Public properties
        /// <summary>
        /// Type of the item
        /// </summary>
        public DirectoryItemType Type { get; set; }
        /// <summary>
        /// The full path to the item
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// Name of the item
        /// </summary>
        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); } }

        /// <summary>
        /// A list of children contained inside this item
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        /// <summary>
        /// Indicates if item can expand
        /// </summary>
        public bool CanExpand { get { return this.Type != DirectoryItemType.File/* && this.Children?.Count(ch => ch != null) > 0*/; } }

        /// <summary>
        /// Shows if the item is already expanded
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                return this.Children?.Count(ch => ch != null) > 0;
            }
            set
            {
                // If UI tells to expand...
                if (value == true)
                    // Find children
                    this.Expand();
                // Otherwise UI tells to close
                else
                    this.ClearChildren();
            }
        }

        #endregion

        #region Public commands

        public ICommand ExpandCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// <param name="fullpath">Full path of the item</param>
        /// <param name="type">Type of the item</param>
        /// </summary>
        public DirectoryItemViewModel(string fullpath, DirectoryItemType type)
        {
            // Create commands
            this.ExpandCommand = new RelayCommand(Expand);

            // Set properties
            this.FullPath = fullpath;
            this.Type = type;

            // Set up the children list
            this.ClearChildren();
        }

        #endregion

        /// <summary>
        /// Expands directory item and finds all children
        /// </summary>
        private void Expand()
        {
            // Cannot expand a file
            if (this.Type == DirectoryItemType.File)
                return;

            // Find all children of the item
            this.Children = new ObservableCollection<DirectoryItemViewModel>(
                    DirectoryStructure.GetDirectoryContents(this.FullPath).Select(content => new DirectoryItemViewModel(content.FullPath, content.Type))
                );
        }

        #region Helper methods

        /// <summary>
        /// Removes all children from the list, adding a dummy item to show the expand icon if required
        /// </summary>
        private void ClearChildren()
        {
            // Clear items by creating a new list
            this.Children = new ObservableCollection<DirectoryItemViewModel>();

            // If not a file, add dummy item to Children list
            if (this.Type != DirectoryItemType.File)
                this.Children.Add(null);
        }

        #endregion
    }
}
