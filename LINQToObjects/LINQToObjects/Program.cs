using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;

namespace LINQToObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            var query1 = from c in Assembly.GetAssembly(typeof(string)).GetTypes()
                        where c.IsInterface
                        orderby c.Name
                        select new
                        {
                            Name = c.Name,
                            NumberOfMethods = c.GetMethods().Length
                        };

            Console.WriteLine("results for query 1:");
            foreach (var c in query1)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine();

            var query2 = from p in Process.GetProcesses()
                    where p.Threads.Count < 5
                    orderby p.Id
                    select new {
                        Name = p.ProcessName,
                        ID = p.Id,
                        Threads = p.Threads.Count
                    };
                    

            Console.WriteLine("results for query 2:");
            foreach (var p in query2)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();
            
            var query3 = from p in Process.GetProcesses()
                         where p.Threads.Count < 5
                         orderby p.Id
                         group p by p.BasePriority into g
                         orderby g.Key
                         select g; 
            
            Console.WriteLine("results for query 3:");
            foreach (IGrouping<int, Process> processesGroup in query3)
            {
                Console.WriteLine("Processes with base priority {0} are:", processesGroup.Key);

                foreach (var process in processesGroup)
                {
                    Console.WriteLine(process.ProcessName);
                } 
                Console.WriteLine();
            }
            Console.WriteLine();

            var query4 = Process.GetProcesses().Select(x => x.Threads.Count).Sum();

            Console.WriteLine("num of threads is {0}", query4);

            // showing copyTo works :)
            Exception e1 = new Exception("Hello", new Exception("goodbye"));
            Exception e2 = new Exception("bye");

            e1.HelpLink = "http://www.google.com";

            e1.CopyTo(e2);

            Console.WriteLine("e2's helplink is - {0}", e2.HelpLink);
        }
    }
}
