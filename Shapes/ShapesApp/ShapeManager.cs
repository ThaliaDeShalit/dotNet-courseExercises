using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeLib;

namespace ShapesApp
{
    class ShapeManager
    {
        private ArrayList _shapes;

        public ShapeManager()
        {
            _shapes = new ArrayList();
        }

        public void Add(Shape shape)
        {
            _shapes.Add(shape);
        }

        public void DisplayAll()
        {
            foreach (Shape shape in _shapes)
            {
                shape.Display();
                Console.WriteLine("shape's area is: {0}{1}", shape.Area, Environment.NewLine);
            }
        }

        public Shape this[int i]
        {
            get 
            { 
                return (Shape)_shapes[i]; 
            }
        }

        public int Count
        {
            get
            {
                return _shapes.Count;
            }
        }

        public StringBuilder Save()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Shape shape in _shapes)
            {
                if (shape is IPersist)
                {
                    (shape as IPersist).Write(sb);
                }
            }

            return sb;
        }
    }
}
