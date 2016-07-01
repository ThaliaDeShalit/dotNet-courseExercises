using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            string[] wordsFromInput;
            string[] reverseWords;
            bool exit = false;
            
            while (!exit)
            {
                Console.WriteLine("please insert a scentence");
                input = Console.ReadLine();

                if (input.Equals(""))
                {
                    exit = true;
                }
                else
                {
                    wordsFromInput = input.Split();

                    Console.WriteLine("Amount of words in input is {0}", wordsFromInput.Length);

                    reverseWords = new string[wordsFromInput.Length];
                    for (int i = 0; i < wordsFromInput.Length; i++)
                    {
                        reverseWords[i] = wordsFromInput[wordsFromInput.Length - i - 1];
                    }

                    Console.WriteLine("The reverse of the input is:{0}{1}", Environment.NewLine, arrToString(reverseWords));

                    Array.Sort(wordsFromInput);

                    Console.WriteLine("The sorted array of the input is:{0}{1}", Environment.NewLine, arrToString(wordsFromInput));
                }
            }
        }

        private static string arrToString(string[] arr)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                sb.Append(arr[i]);
                sb.Append(" ");
            }

            return sb.ToString();
        }
    }  
}
