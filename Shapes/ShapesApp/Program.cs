using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeLib;

namespace ShapesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ShapeManager sm = new ShapeManager();

            Rectangle rec = new Rectangle(2, 4, ConsoleColor.Cyan);
            Ellipse eli = new Ellipse(1, 3, ConsoleColor.Blue);
            Circle crc = new Circle(5, ConsoleColor.Red);

            sm.Add(rec);
            sm.Add(eli);
            sm.Add(crc);

            sm.DisplayAll();

            Console.WriteLine("results of the save method are: {0}{1}", Environment.NewLine, (sm.Save()).ToString());

            sm.Add(new Rectangle(4, 2));

            if ((sm[0] as IComparable).CompareTo(sm[3]) == 0)
            {
                Console.WriteLine("both rectangles have equal areas");
            }
        }
    }
}
