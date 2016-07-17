using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class GameState
    {
        private Player _currPlayer;
        private Player _firstPlayer;
        private Player _secondPlayer;
        private Column[] _board;

        public GameState(string firstPlayerName, string secondPlayerName)
        {
            _firstPlayer = new Player(firstPlayerName, eColor.Black, false);

            _secondPlayer = new Player(secondPlayerName, eColor.White, true);

            _currPlayer = _firstPlayer;

            InstantiateBoard();
        }

        public Player CurrPlayer
        {
            get
            {
                return _currPlayer;
            }
            private set
            {
                _currPlayer = value;
            }
        }

        public Player FirstPlayer
        {
            get
            {
                return _firstPlayer;
            }
        }

        public Player SecondPlayer
        {
            get
            {
                return _secondPlayer;
            }
        }

        public Column[] Board
        {
            get
            {
                return _board;
            }
        }

        private void InstantiateBoard()
        {
            _board = new Column[24];

            _board[0] = new Column(2, eOccupiedColor.White);
            _board[5] = new Column(5, eOccupiedColor.Black);
            _board[7] = new Column(3, eOccupiedColor.Black);
            _board[11] = new Column(5, eOccupiedColor.White);
            _board[12] = new Column(5, eOccupiedColor.Black);
            _board[16] = new Column(3, eOccupiedColor.White);
            _board[18] = new Column(5, eOccupiedColor.White);
            _board[23] = new Column(2, eOccupiedColor.Black);

            for (int i = 0; i < _board.Length; i++)
            {
                if (_board[i] == null)
                {
                    _board[i] = new Column(0, eOccupiedColor.Empty)
                }
            }
        }

        public void NextTurn()
        {
            if (CurrPlayer.Equals(FirstPlayer))
            {
                CurrPlayer = SecondPlayer;
            }
            else
            {
                CurrPlayer = FirstPlayer;
            }
        }
    }
}
