using System.IO;
using DokanNet;

namespace DropboxVirtualSync.DokanyNetMirrorSample
{
    internal static class Notify
    {
        private static string _sourcePath;
        private static string _targetPath;
        private static FileSystemWatcher _commonFsWatcher;
        private static FileSystemWatcher _fileFsWatcher;
        private static FileSystemWatcher _dirFsWatcher;

        public static void Start(string mirrorPath, string mountPath)
        {
            _sourcePath = mirrorPath;
            _targetPath = mountPath;

            _commonFsWatcher = new FileSystemWatcher(mirrorPath)
            {
                IncludeSubdirectories = true,
                NotifyFilter = NotifyFilters.Attributes |
                    NotifyFilters.CreationTime |
                    NotifyFilters.DirectoryName |
                    NotifyFilters.FileName |
                    NotifyFilters.LastAccess |
                    NotifyFilters.LastWrite |
                    NotifyFilters.Security |
                    NotifyFilters.Size
            };

            _commonFsWatcher.Changed += OnCommonFileSystemWatcherChanged;
            _commonFsWatcher.Created += OnCommonFileSystemWatcherCreated;
            _commonFsWatcher.Renamed += OnCommonFileSystemWatcherRenamed;

            _commonFsWatcher.EnableRaisingEvents = true;

            _fileFsWatcher = new FileSystemWatcher(mirrorPath)
            {
                IncludeSubdirectories = true,
                NotifyFilter = NotifyFilters.FileName
            };

            _fileFsWatcher.Deleted += OnCommonFileSystemWatcherFileDeleted;

            _fileFsWatcher.EnableRaisingEvents = true;

            _dirFsWatcher = new FileSystemWatcher(mirrorPath)
            {
                IncludeSubdirectories = true,
                NotifyFilter = NotifyFilters.DirectoryName
            };

            _dirFsWatcher.Deleted += OnCommonFileSystemWatcherDirectoryDeleted;

            _dirFsWatcher.EnableRaisingEvents = true;
        }

        private static string AlterPathToMountPath(string path)
        {
            var relativeMirrorPath = path.Substring(_sourcePath.Length).TrimStart('\\');

            return Path.Combine(_targetPath, relativeMirrorPath);
        }

        private static void OnCommonFileSystemWatcherFileDeleted(object sender, FileSystemEventArgs e)
        {
            var fullPath = AlterPathToMountPath(e.FullPath);

            Dokan.Notify.Delete(fullPath, false);
        }

        private static void OnCommonFileSystemWatcherDirectoryDeleted(object sender, FileSystemEventArgs e)
        {
            var fullPath = AlterPathToMountPath(e.FullPath);

            Dokan.Notify.Delete(fullPath, true);
        }

        private static void OnCommonFileSystemWatcherChanged(object sender, FileSystemEventArgs e)
        {
            var fullPath = AlterPathToMountPath(e.FullPath);

            Dokan.Notify.Update(fullPath);
        }

        private static void OnCommonFileSystemWatcherCreated(object sender, FileSystemEventArgs e)
        {
            var fullPath = AlterPathToMountPath(e.FullPath);
            var isDirectory = Directory.Exists(fullPath);

            Dokan.Notify.Create(fullPath, isDirectory);
        }

        private static void OnCommonFileSystemWatcherRenamed(object sender, RenamedEventArgs e)
        {
            var oldFullPath = AlterPathToMountPath(e.OldFullPath);
            var oldDirectoryName = Path.GetDirectoryName(e.OldFullPath);

            var fullPath = AlterPathToMountPath(e.FullPath);
            var directoryName = Path.GetDirectoryName(e.FullPath);

            var isDirectory = Directory.Exists(e.FullPath);
            var isInSameDirectory = oldDirectoryName.Equals(directoryName);

            Dokan.Notify.Rename(oldFullPath, fullPath, isDirectory, isInSameDirectory);
        }
    }
}
