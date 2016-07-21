using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Player
    {
        private string _name;
        private int _removedCheckers; // checkers that the player got out of the board from the "house" section
        private eColor _color;
        private List<int> _columnsOccupied;
        private bool _isClockwise;
        private int _outsideCheckers; // checkers the other player "ate"

        public Player(string name, eColor color, bool isClockwise, Column[] board)
        {
            _name = name;
            _removedCheckers = 0;
            _color = color;
            InitialzeColumnsOccupied(board); 
            _isClockwise = isClockwise;
            _outsideCheckers = 0;
        }

        private void InitialzeColumnsOccupied(Column[] board)
        {
            _columnsOccupied = new List<int>();
            
            for (int i = 0; i < board.Length; i++)
            {
                if ((int)board[i].Color == (int)Color)
                {
                    ColumnsOccupied.Add(i);
                }
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public int RemovedCheckers
        {
            get
            {
                return _removedCheckers;
            }
            internal set
            {
                _removedCheckers = value;
            }
        }

        public eColor Color
        {
            get
            {
                return _color;
            }
        }

        public List<int> ColumnsOccupied
        {
            get
            {
                return _columnsOccupied;
            } 
        }

        public bool IsClockwise
        {
            get
            {
                return _isClockwise;
            }
        }

        public int OutsideCheckers
        {
            get
            {
                return _outsideCheckers;
            }
            internal set
            {
                _outsideCheckers = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj as Player == this)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
