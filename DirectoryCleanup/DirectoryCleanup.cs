using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryCleanup
{
    public class DirectoryCleanup
    {
        public DirectoryCleanup()
        {
        }

        public void Start()
        {
            //TODO - figure out what will run on the constructor
            //TODO - Start service
            //TODO - stop service
            try
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(@"C:\Users\dbrockert\Downloads");
                if (di.Exists)
                {
                    Console.WriteLine("---------------Files--------------------");
                    foreach (FileInfo file in di.GetFiles())
                    {
                        Console.WriteLine($"{file.Name} is going to be deleted. ");
                        file.Delete();
                    }
                    Console.WriteLine("---------------Directory--------------------");
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        Console.WriteLine($"{dir.Name} is going to be deleted.");
                        dir.Delete(true);
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
            

        }
        public void Stop()
        {

        }
    }
}
