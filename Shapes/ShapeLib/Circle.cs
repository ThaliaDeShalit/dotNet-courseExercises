using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Circle : Ellipse
    {
        public Circle(double radius, ConsoleColor color)
            : base(radius, radius, color)
        {

        }

        public Circle(double radius)
            : base(radius, radius)
        {

        }

        public double Radius
        {
            get
            {
                return Height;
            }
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("Circle radius: {0}", Radius);
        }
    }
}
