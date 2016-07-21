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
                         select g; // what to return
            
            Console.WriteLine("results for query 3:");
            foreach (var p in query3)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();

            var query4 = Process.GetProcesses().Select(x => x.Threads.Count).Sum();

            Console.WriteLine("num of threads is {0}", query4);


        }

        public static void CopyTo(this object obj, object otherObj)
        {
            var query = from p in obj.GetType().GetProperties()
                             from q in otherObj.GetType().GetProperties()
                             where p.CanRead && q.CanWrite && p.Name == q.Name
                             select new
                             {
                                 p,
                                 q
                             };

            foreach (var v in query)
            {
                v.q.SetValue(otherObj, v.p.GetValue(obj));
            }
        }
    }
}
