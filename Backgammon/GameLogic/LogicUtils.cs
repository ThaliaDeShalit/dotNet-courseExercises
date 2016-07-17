using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public struct sMove
    {
        private int? _column;
        private int _die;
        private eTypeOfMove _type;

        public sMove(int? column, int die, eTypeOfMove type)
        {
            _column = column;
            _die = die;
            _type = type;
        }

        public int? Column
        {
            get
            {
                return _column;
            }
        }

        public int Die
        {
            get
            {
                return _die;
            }
        }

        public eTypeOfMove Type
        {
            get
            {
                return _type;
            }
        }
    }

    public enum eTypeOfMove 
    {
        In,
        Regular
    }

    public enum eColor
    {
        Black,
        White
    }

    public enum eOccupiedColor
    {
        Black,
        White,
        Empty
    }
}
