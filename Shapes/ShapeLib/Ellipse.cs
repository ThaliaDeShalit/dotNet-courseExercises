using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Ellipse : Shape, IPersist, IComparable
    {
        private double _width;
        private double _height;

        public Ellipse(double width, double height, ConsoleColor color)
            : base(color)
        {
            _width = width;
            _height = height;
        }

        public Ellipse(double width, double height)
            : base()
        {
            _width = width;
            _height = height;
        }

        public double Width
        {
            get
            {
                return _width;
            }
        }

        public double Height
        {
            get
            {
                return _height;
            }
        }

        public override double Area
        {
            get
            {
                return Math.PI * Width * Height;
            }
        }

        public override void Display()
        {
            base.Display();

            if (!(this is Circle))
            {
                Console.WriteLine("Ellipse width: {0}, Ellipse height: {1}", Width, Height);
            }
        }

        public void Write(StringBuilder sb)
        {
            sb.AppendLine(String.Format("Ellipse width: {0}, Ellipse height: {1}", Width, Height));
        }

        public int CompareTo(object obj)
        {
            if (obj != null)
            {
                Shape otherShape = obj as Shape;
                if (otherShape != null)
                {
                    return Area.CompareTo(otherShape.Area);
                }
            }

            throw new ArgumentException("Object is not a Shape");
        }
    }
}
