using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Reflection;

namespace XLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            XElement root = new XElement("Classes",
                from c in Assembly.GetAssembly(typeof(string)).GetTypes()
                where c.IsClass && c.IsPublic
                select new XElement("Type",
                    new XAttribute("FullName", c.FullName),
                    new XElement("Properties",
                      from p in c.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                      select new XElement("Property",
                        new XAttribute("Name", p.Name),
                        new XAttribute("Type", p.PropertyType))),
                    new XElement("Methods",
                        from m in c.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                        where !m.IsSpecialName
                        select new XElement("Method",
                            new XAttribute("Name", m.Name),
                            new XAttribute("ReturnType", m.ReturnType),
                            new XElement("Parameters",
                                from param in m.GetParameters()
                                select new XElement("Parameter",
                                new XAttribute("Name", param.Name),
                                new XAttribute("Type", param.GetType())))))));

            root.Save("test.xml");

            var query1 = from t in root.Descendants("Type")
                        where t.Element("Properties").IsEmpty
                        orderby (string)t.Attribute("FullName")
                        select (string)t.Attribute("FullName");

            foreach (var t in query1)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine("for a total of {0} of types with no properties", query1.ToList().Count);
            Console.WriteLine();

            var query2 = (from m in root.Descendants("Method")
                         select m).ToList().Count;

            Console.WriteLine("There are {0} methods in the XML", query2);
            Console.WriteLine();

            var query3 = (from p in root.Descendants("Property")
                          select p).ToList().Count;

            Console.WriteLine("There are {0} properties in the XML", query3);
            Console.WriteLine();

            var query4 = from p in root.Descendants("Parameter")
                         group p by (string)p.Attribute("Type") into g
                         orderby g.ToList().Count
                         select g;

            Console.WriteLine("the param type most used is {0}", query4.ToList()[query4.ToList().Count - 1].Key);
            Console.WriteLine();

            XElement newXml = new XElement("Types", 
                                from t in root.Descendants("Type")
                                orderby (from m in t.Descendants("Method")
                                         select m).ToList().Count descending
                                select new XElement("Type",
                                    new XAttribute("FullName", (string)t.Attribute("FullName")),
                                    new XAttribute("NumOfProperties", (from p in t.Descendants("Property")
                                                                       select p).ToList().Count),
                                    new XAttribute("NumOfMetods", (from m in t.Descendants("Method")
                                                                   select m).ToList().Count)));

            newXml.Save("newTest.xml");

            var query5 = from t in root.Descendants("Type")
                         orderby (string)t.Attribute("FullName") ascending
                         group t by ((from m in t.Descendants("Method")
                                      select m).ToList().Count) into g
                         orderby g.Key descending
                         select g;

            foreach (IGrouping<int, XElement> group in query5)
            {
                // Hi Alex, the reason i decided to skip the 0 key is to be able to see in the CMD the rest of the groups,
                // as group 0 has so many types that it is the only thing avilable to see in cmd.
                // if you would like to see it too you can comment out the if
                if (group.Key == 0)
                {
                    continue;
                }
                Console.WriteLine("types with {0} methods are", group.Key);

                foreach (var element in group)
                {
                    Console.WriteLine(element.Attribute("FullName"));
                }
                Console.WriteLine();
            }
        }
    }
}
