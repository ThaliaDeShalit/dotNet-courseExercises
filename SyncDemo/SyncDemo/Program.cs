using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace SyncDemo
{
    class Program
    {
        public static void Main()
        {
            Mutex SyncFileMutex = new Mutex(false, "syncFileMutex");

            FileStream fs = null;
            StreamWriter sr = null;

            for (int i = 0; i < 10000; i++)
            {

                SyncFileMutex.WaitOne();
                try
                {
                    fs = new FileStream("C:/Windows.old/Windows/Temp/data.txt", FileMode.Append, FileAccess.Write, FileShare.Write);
                    sr = new StreamWriter(fs);
                    sr.WriteLine($"Process ID of process is {Process.GetCurrentProcess().Id} and this is the {i} line");
                    fs.Flush();
                    sr.Flush();
                }
                catch (Exception e)
                {
                    
                }
                finally
                {
                    sr.Close();
                    fs.Close();
                }

                SyncFileMutex.ReleaseMutex();
            }




        }
    }
}
