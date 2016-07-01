using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Rectangle : Shape, IPersist, IComparable
    {
        private double _width;
        private double _height;

        public Rectangle(double width, double height, ConsoleColor color) 
            : base(color)
        {
            _width = width;
            _height = height;
        }

        public Rectangle(double width, double height)
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
                return Width * Height;
            }
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("Rectangle width: {0}, Rectangle height: {1}", Width, Height);
        }

        public void Write(StringBuilder sb)
        {
            sb.AppendLine(String.Format("Rectangle width: {0}, Rectangle height: {1}", Width, Height));
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
