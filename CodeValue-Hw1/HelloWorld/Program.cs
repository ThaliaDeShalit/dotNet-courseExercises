using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            string output = String.Format(@"Hello, C#!
My name is Thalia De Shalit, 
and I am currently living in the student dorms of Tel Aviv University,
which is located in 20th George Wize street, TLV");
            Console.WriteLine(output);
        }
    }
}
