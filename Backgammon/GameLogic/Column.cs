using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    class Column
    {
        private int _count;
        private eOccupiedColor _color;

        public Column(int count, eOccupiedColor color)
        {
            _count = count;
            _color = color;
        }

        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
            }
        }

        public eOccupiedColor Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }
    }
}
