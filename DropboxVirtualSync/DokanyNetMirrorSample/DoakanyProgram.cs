using System;
using DokanNet;
using DropboxVirtualSync.Views;

namespace DropboxVirtualSync.DokanyNetMirrorSample
{
    internal class DoakanyProgram
    {
        private readonly MainWindow _mainWindow;

        public DoakanyProgram(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public void MountMirror()
        {
            try
            {
                var mirrorPath = _mainWindow.SourcePathTextBox.Text;

                var mountPath = _mainWindow.SourcePathTextBox.Text;

                Notify.Start(mirrorPath, mountPath);

                var mirror = StartUnsafeMirror(mirrorPath);  // Safe mirror: new Mirror(mirrorPath);
                
                mirror.Mount(mountPath, DokanOptions.DebugMode | DokanOptions.EnableNotificationAPI, 5);

                Console.WriteLine(@"Success");
            }
            catch (DokanException ex)
            {
                Console.WriteLine(@"Error: " + ex.Message);
            }
        }

        private static UnsafeMirror StartUnsafeMirror(string mirrorPath)
        {
            Console.WriteLine($"Using unsafe methods");

            var mirror = new UnsafeMirror(mirrorPath);
            
            return mirror;
        }
    }
}