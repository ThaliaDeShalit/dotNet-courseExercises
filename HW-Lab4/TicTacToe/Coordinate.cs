using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    struct Coordinate
    {
        private int _x;
        private int _y;

        internal Coordinate(int x, int y)
        {
            _x = x;
            _y = y;
        }

        internal int X
        {
            get
            {
                return _x;
            }
        }

        internal int Y
        {
            get
            {
                return _y;
            }
        }

        internal static bool TryParse(string str, out Coordinate c)
        {
            bool wasParseSuccesful = false;
            char[] splitCharacters = {','};
            string[] splitedString = str.Split(splitCharacters);
            int x, y;

            if (splitedString.Length == 2)
            {
                if (int.TryParse(splitedString[0], out x) && int.TryParse(splitedString[1], out y))
                {
                    c = new Coordinate(x, y);
                    wasParseSuccesful = true;
                }
                else
                {
                    c = new Coordinate(0, 0);
                }
            }
            else
            {
                c = new Coordinate(0, 0);
            }

            return wasParseSuccesful;
        }
    }
}
