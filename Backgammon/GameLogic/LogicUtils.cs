using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    class LogicUtils
    {
        
    }

    struct sCoordinateOnBoard
    {
        private int _x;
        private int _y;

        public sCoordinateOnBoard(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int X
        {
            get
            {
                return _x;
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }
        }

    }

    public enum eBoardLocation
    {
        Black,
        White,
        Empty
    }

    public enum eColor
    {
        Black,
        White
    }

    public struct sDiceRolls
    {
        int _firstDice;
        int _secondDice;

        public sDiceRolls(int x, int y)
        {
            _firstDice = x;
            _secondDice = y;
        }

        public int FirstDice
        {
            get
            {
                return _firstDice;
            }
        }

        public int SecondDice
        {
            get
            {
                return _secondDice;
            }
        }

        public static int DiceRoll()
        {
            return new Random().Next(1, 6);
        }
    }
}
