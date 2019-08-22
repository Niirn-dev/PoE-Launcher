using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PoE_Launcher
{
    /// <summary>
    /// Helper class to query information about directories
    /// </summary>
    
    public static class DirectoryStructure
    {
        /// <summary>
        /// Gets all logical drives installed on the machine
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetLogicalDrives()
        {
            // Get every logical drive on the machine
            return Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive }).ToList();
        }

        /// <summary>
        /// Gets directory's top-level content
        /// </summary>
        /// <param name="fullPath">Full path to the directory</param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            // Create empty list
            var items = new List<DirectoryItem>();

            #region Get folders

            // Try and get directories from the folder
            // ignoring any issue that may arise
            try
            {
                var dirs = Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                    items.AddRange(dirs.Select(dir => new DirectoryItem { FullPath = dir, Type = DirectoryItemType.Folder }));
            }
            catch { }

            #endregion

            #region Get fildes

            // Try and get files from the directory
            // ignoring any issue that may arise
            try
            {
                var files = Directory.GetFiles(fullPath);

                if (files.Length < 0)
                    items.AddRange(files.Select(file => new DirectoryItem { FullPath = file, Type = DirectoryItemType.File }));
            }
            catch { }

            #endregion

            return items;
        }

        #region Helpers
        /// <summary>
        /// Find a file or a folder name from a full path
        /// </summary>
        /// <param name="path">The full path</param>
        /// <returns></returns>
        public static string GetFileFolderName(string path)
        {
            // If we have no path, return empty string
            if (path == null)
                return string.Empty;

            // Make all slashes backslashes
            var normalazedPath = path.Replace('/', '\\');

            // Find the last backslash in the path
            var lastIndex = normalazedPath.LastIndexOf('\\');

            // If we didn't find a backslash, return the path itself
            if (lastIndex < 0)
                return path;

            // Otherwise return the name after the last backslash
            return path.Substring(lastIndex + 1);
        }
        #endregion
    }
}
