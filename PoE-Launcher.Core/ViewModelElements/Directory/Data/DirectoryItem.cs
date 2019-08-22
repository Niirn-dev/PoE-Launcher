namespace PoE_Launcher.Core
{
    /// <summary>
    /// Information about a directory item such as a drive, a folder  or a file
    /// </summary>
    public class DirectoryItem
    {
        #region Public properties
        /// <summary>
        /// Type of the directory item
        /// </summary>
        public DirectoryItemType Type { get; set; }
        /// <summary>
        /// The absolute path to the item
        /// </summary>
        public string FullPath { get; set;}
        /// <summary>
        /// Name of the directory item
        /// </summary>
        public string Name
        {
            get
            {
                return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(FullPath);
                
            }
        }
        
        #endregion
    }
}
