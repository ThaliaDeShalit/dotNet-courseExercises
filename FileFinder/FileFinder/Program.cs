using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = args[0];
            string text = args[1];

            List<sFileInfo> filesContainingText = new List<sFileInfo>();

            DirectoryProbing(ref filesContainingText, path, text);

            Console.WriteLine("files containig the string {0} in {1} directory are:", text, path);
            foreach (sFileInfo file in filesContainingText)
            {
                Console.WriteLine("{0} with length {1}", file.FileName, file.FileLength);
            }
        }

        static void DirectoryProbing(ref List<sFileInfo> filesContainingText, string path, string text)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            List<string> directories = new List<string>(Directory.EnumerateDirectories(path));

            foreach (FileInfo file in di.EnumerateFiles())
            {
                if (file.Name.Contains(text))
                {
                    filesContainingText.Add(new sFileInfo(file.Name, file.Length.ToString()));
                }
            }

            // recursion part
            foreach (string directory in directories)
            {
                DirectoryProbing(ref filesContainingText, directory, text);
            }
        }
    }

    struct sFileInfo
    {
        private string _fileName;
        private string _fileLength;

        public sFileInfo(string fileName, string fileLength)
        {
            _fileName = fileName;
            _fileLength = fileLength;
        }

        internal string FileName
        {
            get
            {
                return _fileName;
            }
        }

        internal string FileLength
        {
            get
            {
                return _fileLength;
            }
        }
    }
}
