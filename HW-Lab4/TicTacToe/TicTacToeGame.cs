using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class TicTacToeGame
    {
        private const int BOARD_SIZE = 3;

        private eCell[,] board = new eCell[BOARD_SIZE, BOARD_SIZE];
        private bool isXTurn;
        private bool isGameOver;

        internal TicTacToeGame()
        {
            for (int i = 0; i < BOARD_SIZE; i++) 
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    board[i, j] = eCell.Empty;
                }
            }

            isXTurn = true;
            isGameOver = false;
        }

        internal void DisplayBoard()
        {
            string horizontalLine = "---------";
            string verticalLine = " | ";
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    switch (board[i, j])
                    {
                        case eCell.X:
                            sb.Append("X");
                            break;
                        case eCell.O:
                            sb.Append("O");
                            break;
                        case eCell.Empty:
                            sb.Append(" ");
                            break;
                    }

                    if (j < BOARD_SIZE - 1)
                    {
                        sb.Append(verticalLine);
                    }
                }

                if (i < BOARD_SIZE - 1)
                {
                    sb.Append(Environment.NewLine);
                    sb.Append(horizontalLine);
                    sb.Append(Environment.NewLine);

                }
            }

            Console.WriteLine(sb.ToString());
        }

        internal bool TrySetMove(Coordinate c)
        {
            if (isMoveValid(c))
            {
                if (isXTurn)
                {
                    board[c.X - 1, c.Y - 1] = eCell.X;
                    isXTurn = false;
                }
                else
                {
                    board[c.X - 1, c.Y - 1] = eCell.O;
                    isXTurn = true;
                }

                IsGameOver = checkIfGameOver();
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool isMoveValid(Coordinate c)
        {
            if (c.X <= BOARD_SIZE && c.Y <= BOARD_SIZE && c.X > 0 && c.Y > 0)
            {
                if (board[c.X - 1, c.Y - 1] == eCell.Empty)
                {
                    return true;
                }
            }

            return false;
        }

        internal bool IsGameOver 
        {
            get
            {
                return isGameOver;
            }
            private set
            {
                isGameOver = value;
            }
        }

        private bool checkIfGameOver()
        {
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                if (board[i, 0] != eCell.Empty && board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2])
                {
                    return true;
                }
            }

            for (int i = 0; i < BOARD_SIZE; i++)
            {
                if (board[0, i] != eCell.Empty && board[0, i] == board[1, i] && board[0, i] == board[2, i])
                {
                    return true;
                }
            }

            if (board[0, 0] != eCell.Empty && board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2])
            {
                return true;
            }

            if (board[0, 2] != eCell.Empty && board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0])
            {
                return true;
            }

            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    if (board[i, j] == eCell.Empty)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }

    enum eCell
    {
        X,
        O,
        Empty
    }


}
