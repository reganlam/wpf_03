using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace treeView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region constructor
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region On Loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Get every logical drive
            foreach (var drive in System.IO.Directory.GetLogicalDrives())
            {
                var item = new TreeViewItem()
                {
                    Header = drive,     // Header = File name
                    Tag = drive         // Tag = Full path
                };

                //item.Header = drive;
                //item.Tag = drive;

                item.Items.Add(null);

                item.Expanded += Folder_Expanded;
                FolderView.Items.Add(item);
            }
        }
        #endregion

        #region Folder Expanded
        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            var item = (TreeViewItem)sender;

            // If does not contain dummy data means we have already iterated
            if (item.Items.Count != 1 || item.Items[0] != null) return;

            item.Items.Clear();

            var fullPath = (string)item.Tag;


            #region Get directories
            // Get directories within item
            var directories = new List<String>();

            try
            {
                // Get each folder in directory
                var dirs = System.IO.Directory.GetDirectories(fullPath);

                 directories.AddRange(dirs);
            }
            catch
            {

            }

            directories.ForEach(directoryPath =>
            {
                var subItem = new TreeViewItem()
                {
                    Header = System.IO.Path.GetFileName(directoryPath),
                    Tag = directoryPath
                };

                // Add dummy item for expand
                subItem.Items.Add(null);

                subItem.Expanded += Folder_Expanded;

                item.Items.Add(subItem);
            });
            #endregion

            #region Get files
            // Get files within item
            var files = new List<String>();

            try
            {
                // Get each file in directory
                var fs = System.IO.Directory.GetFiles(fullPath);

                files.AddRange(fs);
            }
            catch
            {

            }

            files.ForEach(directoryPath =>
            {
                var subItem = new TreeViewItem()
                {
                    Header = System.IO.Path.GetFileName(directoryPath),
                    Tag = directoryPath
                };

                item.Items.Add(subItem);
            });
            #endregion
        }
        #endregion
    }
}
