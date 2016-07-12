using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AttribDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isAllApproved = AnalyzeAssembly(Assembly.GetExecutingAssembly());

            Console.WriteLine("was all aproved? {0}", isAllApproved.ToString());
            Console.WriteLine();

            isAllApproved = AnalyzeAssembly(Assembly.GetAssembly(typeof(Console)));
            Console.WriteLine("was all aproved? {0}", isAllApproved.ToString());
        }

        static bool AnalyzeAssembly(Assembly a)
        {
            bool result = true;
            Type attType = typeof(CodeReviewAttribute);

            foreach (Type type in a.GetTypes())
            {
                if (type.IsDefined(attType))
                {
                    object[] attributes = type.GetCustomAttributes(attType, true);
                    CodeReviewAttribute att = (CodeReviewAttribute)attributes[0];

                    Console.WriteLine(
@"CodeReviewAttribute found!
Reviewer name: {0}
Review date: {1}", att.ReviewerName, att.ReviewDate);

                    if (att.IsApproved)
                    {
                        Console.WriteLine("The review was approved");
                    }
                    else
                    {
                        Console.WriteLine("The review was not approved");
                        result = false;
                    }

                    Console.WriteLine();
                }
            }

            return result;
        }
    }
}
