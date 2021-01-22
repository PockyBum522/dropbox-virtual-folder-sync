using System;
using System.Linq;
using DokanNet;

namespace DokanNetMirror
{
    internal class Program
    {
        private const string MirrorKey = "-what";
        private const string MountKey = "-where";
        private const string UseUnsafeKey = "-unsafe";

        public static void DokanyMain(string[] args)
        {
            try
            {
                var arguments = args
                   .Select(x => x.Split(new char[] { '=' }, 2, StringSplitOptions.RemoveEmptyEntries))
                   .ToDictionary(x => x[0], x => x.Length > 1 ? x[1] as object : true, StringComparer.OrdinalIgnoreCase);

                var mirrorPath = arguments.ContainsKey(MirrorKey)
                   ? arguments[MirrorKey] as string
                   : @"\\w2k3nas1\EngData\Admin\Windows Common\Libraries";

                var mountPath = arguments.ContainsKey(MountKey)
                   ? arguments[MountKey] as string
                   : @"D:\Dropbox\Backups\TI Backups\Test Mirror";

                var unsafeReadWrite = arguments.ContainsKey(UseUnsafeKey);

                Notify.Start(mirrorPath, mountPath);

                Console.WriteLine($"Using unsafe methods: {unsafeReadWrite}");
                var mirror = unsafeReadWrite 
                    ? new UnsafeMirror(mirrorPath) 
                    : new Mirror(mirrorPath);
                mirror.Mount(mountPath, DokanOptions.DebugMode | DokanOptions.EnableNotificationAPI, 5);

                Console.WriteLine(@"Success");
            }
            catch (DokanException ex)
            {
                Console.WriteLine(@"Error: " + ex.Message);
            }
        }
    }
}