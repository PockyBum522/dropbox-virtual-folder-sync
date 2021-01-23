using System.Windows.Forms;

namespace DropboxVirtualSync.Logic
{
    public class FolderBrowser
    {
        private FolderBrowserDialog _folderBrowserDialog1;

        public string BrowseForFolderPath()
        {
            _folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();

            // Show the FolderBrowserDialog.
            DialogResult result = _folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                return _folderBrowserDialog1.SelectedPath;
            }

            return "";
        }
    }
}