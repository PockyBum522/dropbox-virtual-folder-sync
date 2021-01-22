using System;

namespace DropboxVirtualSync
{
    public class LazyLocalization
    {
        private MainWindow _mainWindow;

        public LazyLocalization(MainWindow mainWindow)
        {
            AddTextBoxPrefillPerUsername();
            _mainWindow = mainWindow;
        }

        private void AddTextBoxPrefillPerUsername()
        {
            var userName = Environment.UserName;

            if (userName == "David")
            {
                _mainWindow.SourcePathTextBox.Text = @"\\w2k3nas1\EngData\Admin\Windows Common\Libraries";
                _mainWindow.DestinationPathTextBox.Text = @"D:\Dropbox\Backups\TI Backups\Test Mirror";
            }
        }
    }
}