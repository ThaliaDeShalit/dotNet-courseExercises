using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostumersApp
{
    internal delegate bool CostumerFilter(Costumer costumer);

    class Program
    {
        static void Main(string[] args)
        {
            Costumer c1 = new Costumer("Tal", 1, "bla");
            Costumer c2 = new Costumer("Dan", 3, "bla bla");
            Costumer c3 = new Costumer("Or", 2, "foo");
            Costumer c4 = new Costumer("Ziv", 101, "bar");
            Costumer c5 = new Costumer("Gal", 4, "poop");
            StringBuilder sb = new StringBuilder();

            Costumer[] costumers = new Costumer[] { c1, c2, c3, c4, c5 };

            for (int i = 0; i < costumers.Length; i++)
            {
                sb.Append("client number ");
                sb.Append(i + 1);
                sb.Append(" is:");
                sb.Append(Environment.NewLine);

                sb.Append("Name: ");
                sb.Append(costumers[i].Name);
                sb.Append(Environment.NewLine);
                sb.Append("ID: ");
                sb.Append(costumers[i].ID);
                sb.Append(Environment.NewLine);
                sb.Append("Address: ");
                sb.Append(costumers[i].Address);
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);
            }

            Console.WriteLine(sb.ToString());

            Array.Sort(costumers);

            Console.WriteLine("the sorted costumers according to names are:");
            foreach (Costumer costumer in costumers)
            {
                Console.WriteLine(costumer.Name);
            }

            Console.WriteLine();

            Array.Sort(costumers, new AnotherCustomerComparer());

            Console.WriteLine("the sorted costumers according to IDs are:");
            foreach (Costumer costumer in costumers)
            {
                Console.WriteLine(costumer.Name);
            }

            Console.WriteLine();

            // new stuff for exercise 4
            CostumerFilter cf = new CostumerFilter(Filter);

            List<Costumer> filteredCostumers = GetCostumers(costumers, cf);
            
            Console.WriteLine("the costumers with names with first letter between a-k are:");
            foreach (Costumer costumer in filteredCostumers)
            {
                Console.WriteLine(costumer.Name);
            }

            Console.WriteLine();

            filteredCostumers.Clear();

            filteredCostumers = GetCostumers(costumers, delegate(Costumer c) {
                return (c.Name[0] >= 'L' && c.Name[0] <= 'Z') || (c.Name[0] >= 'l' && c.Name[0] <= 'z');
            });

            Console.WriteLine("the costumers with names with first letter between l-z are:");
            foreach (Costumer costumer in filteredCostumers)
            {
                Console.WriteLine(costumer.Name);
            }

            Console.WriteLine();

            filteredCostumers.Clear();

            filteredCostumers = GetCostumers(costumers, c => {
                return c.ID < 100;
            });

            Console.WriteLine("the costumers with IDs less than 100 are:");
            foreach (Costumer costumer in filteredCostumers)
            {
                Console.WriteLine("{0}, ID #{1}", costumer.Name, costumer.ID);
            }
        }

        private static List<Costumer> GetCostumers(ICollection<Costumer> costumers, CostumerFilter filter)
        {
            List<Costumer> filteredCostumers = new List<Costumer>();
            
            foreach (Costumer costumer in costumers)
            {
                if (filter(costumer))
                {
                    filteredCostumers.Add(costumer);
                }
            }
            
            return filteredCostumers;
        }

        private static bool Filter(Costumer c)
        {
            return (c.Name[0] >= 'A' && c.Name[0] <= 'K') || (c.Name[0] >= 'a' && c.Name[0] <= 'k');
        }
    }
}
