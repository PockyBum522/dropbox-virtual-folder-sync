using System;
using DropboxVirtualSync.Views;

namespace DropboxVirtualSync.Logistics
{
    public class LazyLocalization
    {
        private readonly MainWindow _mainWindow;

        public LazyLocalization(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        internal void AddTextBoxPrefillPerUsername()
        {
            var userName = Environment.UserName;

            if (userName == "David")
            {
                _mainWindow.SourcePathTextBox.Text = @"\\w2k3nas1\EngData\Admin\Windows Common\Libraries";
                _mainWindow.DestinationPathTextBox.Text = @"D:\Dropbox\Backups\TI Backups\Test Mirror";
            }      
            
            if (userName == "jmash")
            {
                _mainWindow.SourcePathTextBox.Text = @"HI JURRRRRD";
                _mainWindow.DestinationPathTextBox.Text = @"yo momma";
            }
        }
    }
}