namespace treeView.Directory.Data
{
    /// <summary>
    /// Information about a directory item such as a drive, file or folder
    /// </summary>
    class DirectoryItem
    {
        /// <summary>
        /// Type of item
        /// </summary>
        public DirectoryItemType Type { get; set; }

        /// <summary>
        /// The absolute path to the item
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// The name of this item
        /// </summary>
        public string Name { get { return System.IO.Path.GetFileName(this.FullPath); } }
    }
}
