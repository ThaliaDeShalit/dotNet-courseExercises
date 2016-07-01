using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public abstract class Shape
    {
        ConsoleColor _color;

        public Shape(ConsoleColor color)
        {
            _color = color;
        }

        public Shape()
        {
            _color = ConsoleColor.White;
        }

        public ConsoleColor Color
        {
            get
            {
                return _color;
            }
        }

        public virtual void Display()
        {
            Console.ForegroundColor = Color;
        }

        public abstract double Area
        {
            get;
        }
    }
}
