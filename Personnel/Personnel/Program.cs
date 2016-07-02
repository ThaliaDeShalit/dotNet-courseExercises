using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Personnel
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:/Users/Thalia/Desktop/CodeValue/HW/Personnel/TestFile.txt";

            StreamReader sr = File.OpenText(path);

            List<string> dataFromFile = new List<string>();

            string s;
            while ((s = sr.ReadLine()) != null)
            {
                dataFromFile.Add(s);
            }

            foreach (string str in dataFromFile)
            {
                Console.WriteLine(str);
            }
        }
    }
}
