using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MultiDictionary<int, string> dictionary = new MultiDictionary<int, string>();

            dictionary.Add(1, "one");
            dictionary.Add(2, "two");
            dictionary.Add(3, "three");
            dictionary.Add(1, "ich");
            dictionary.Add(2, "nee");
            dictionary.Add(3, "sun");

            printDictionary(dictionary);

            // check add
            dictionary.Add(10, "ten");
            printDictionary(dictionary);

            // cheack remove by key
            dictionary.Remove(2);
            printDictionary(dictionary);

            // check remove by key and value
            dictionary.Remove(3, "sun");
            printDictionary(dictionary);
            
            // check contains key
            if (dictionary.ContainsKey(10))
            {
                Console.WriteLine("It Works!");
            }
            else
            {
                Console.WriteLine("It Works... not.");
            }

            // check contains value
            if (!dictionary.Contains(10, "ju"))
            {
                Console.WriteLine("It Works!");
            }
            else
            {
                Console.WriteLine("It Works... not.");
            }

            // check count
            Console.WriteLine("there are {0} values in the dictionary", dictionary.Count);
            printDictionary(dictionary);

            // check clear
            dictionary.Clear();
            printDictionary(dictionary);
        }

        private static void printDictionary(MultiDictionary<int, string> d)
        {
            Console.WriteLine("dictionary now contains -");
            foreach (KeyValuePair<int, string> entry in d)
            {
                Console.WriteLine("{0}, {1}", entry.Key, entry.Value);
            }

            Console.WriteLine(Environment.NewLine);
        }
    }
}
