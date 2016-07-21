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
        private Player _otherPlayer;
        private Player _firstPlayer;
        private Player _secondPlayer;
        private Column[] _board;

        public GameState(string firstPlayerName, string secondPlayerName, int firstPlayerDie, int secondPlayerDie)
        {
            InstantiateBoard();

            _firstPlayer = new Player(firstPlayerName, eColor.White, true, _board);

            _secondPlayer = new Player(secondPlayerName, eColor.Black, false, _board);

            SetPlayerThatPlaysFirst(firstPlayerDie, secondPlayerDie);
        }

        public void SetPlayerThatPlaysFirst(int firstPlayerDie, int secondPlayerDie)
        {
            if (firstPlayerDie > secondPlayerDie)
            {
                CurrPlayer = FirstPlayer;
                OtherPlayer = SecondPlayer;
            }
            else
            {
                CurrPlayer = SecondPlayer;
                OtherPlayer = FirstPlayer;
            }
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

        public Player OtherPlayer
        {
            get
            {
                return _otherPlayer;
            }
            private set
            {
                _otherPlayer = value;
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
                    _board[i] = new Column(0, eOccupiedColor.Empty);
                }
            }
        }

        public void NextTurn()
        {
            if (CurrPlayer.Equals(FirstPlayer))
            {
                CurrPlayer = SecondPlayer;
                OtherPlayer = FirstPlayer;
            }
            else
            {
                CurrPlayer = FirstPlayer;
                OtherPlayer = SecondPlayer;
            }
        }
    }
}
