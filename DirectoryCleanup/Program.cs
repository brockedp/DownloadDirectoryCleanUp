using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace DirectoryCleanup
{
    class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<DirectoryCleanup>(s =>
                {
                    s.ConstructUsing(directoryCleanup => new DirectoryCleanup());
                    s.WhenStarted(directoryCleanup => directoryCleanup.Start());
                    s.WhenStopped(directoryCleanup => directoryCleanup.Stop());
                    
                    
                });
                x.StartManually();
                x.RunAsLocalSystem();
                x.SetServiceName("DownloadDirectoryCleanup");
                x.SetDisplayName("Download Directory Cleanup");
                x.SetDescription("This service deletes all files and directories in the Downloads folder");
            });
            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;

        }
    }
    
}
