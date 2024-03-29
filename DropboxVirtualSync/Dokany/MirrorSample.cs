using System;
using DokanNet;
using DropboxVirtualSync.Dokany.Dependencies;
using DropboxVirtualSync.Views;

namespace DropboxVirtualSync.Dokany
{
    internal class MirrorSample
    {
        private readonly MainWindow _mainWindow;

        public MirrorSample(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public void MountMirror()
        {
            try
            {
                var mirrorPath = _mainWindow.SourcePathTextBox.Text;

                var mountPath = _mainWindow.DestinationPathTextBox.Text;

                Notify.Start(mirrorPath, mountPath);

                var mirror = StartUnsafeMirror(mirrorPath);  // Safe mirror: new Mirror(mirrorPath);
                
                mirror.Mount(mountPath, DokanOptions.MountManager, 1);

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