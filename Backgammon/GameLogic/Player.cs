using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    class Player
    {
        private string _name;
        private eColor _color;
        private List<sCoordinateOnBoard> _validMoves;
        private List<sCoordinateOnBoard> _coordinatesOccupied;

        public Player(string name, eColor color, List<sCoordinateOnBoard> startingPosition)
        {
            _name = name;
            _color = color;
            _validMoves = new List<sCoordinateOnBoard>();
            _coordinatesOccupied = new List<sCoordinateOnBoard>();

            foreach (sCoordinateOnBoard coordinate in startingPosition)
            {
                _coordinatesOccupied.Add(coordinate);
            }
        }
    }
}
