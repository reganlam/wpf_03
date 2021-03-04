using System.Collections.Generic;
using System.Linq;
using treeView.Directory.Data;

namespace treeView
{
    /// <summary>
    /// Helper class to query information about directories
    /// </summary>
    class DirectoryStructure
    {
        public static List<DirectoryItem> GetLogicalDrives()
        {
            return System.IO.Directory.GetLogicalDrives().Select((drive) => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive }).ToList();
        }

        /// <summary>
        /// Get Directory top level content
        /// </summary>
        /// <param name="fullPath">Full path to directory</param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            // Get file/folder contents
            var items = new List<DirectoryItem>();

            #region Add directories
            try
            {
                // Get each folder in directory
                var dirs = System.IO.Directory.GetDirectories(fullPath);

                if(dirs.Length > 0)
                {
                    items.AddRange(dirs
                        .Select((dir) => new DirectoryItem { FullPath = dir, Type = DirectoryItemType.Folder }));
                }
            }
            catch
            {

            }
            #endregion

            #region Add files
            // Get files within item
            try
            {
                // Get each file in directory
                var fs = System.IO.Directory.GetFiles(fullPath);

                if(fs.Length > 0)
                {
                    items.AddRange(fs
                        .Select((file) => new DirectoryItem { FullPath = file, Type = DirectoryItemType.File }));
                }
            }
            catch
            {

            }
            #endregion

            return items;
        }
    }
}
