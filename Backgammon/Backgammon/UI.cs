using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic;

namespace Backgammon
{
    public class UI
    {
        private const string VerticalLineEnd = "||";
        private const string VerticalLine = "|";
        private const string BlackCell = " X ";
        private const string WhiteCell = " O ";
        private const string EmptyCell = "   ";
        private const string MiddleRow =      "||                       ||                       ||\n";
        private const string HorizontalLine = "----------------------------------------------------\n";
        private const string TopRow = "  13  14  15  16  17  18   19  20  21  22  23  24\n";
        private const string bottomRow = "  12  11  10   9   8   7    6   5   4   3   2   1\n";

        public string GetName(string str)
        {
            string nameOfPlayer;

            Console.WriteLine("Please enter the name of the {0} player:", str);
            while (string.IsNullOrWhiteSpace(nameOfPlayer = Console.ReadLine()))
            {
                Console.WriteLine("Name is invalid, please enter a valid name");
            }

            return nameOfPlayer;
        }

        public void DrawBoard(Column[] board)
        {
            Console.Clear();

            StringBuilder sb = new StringBuilder();
            sb.Append(TopRow);
            sb.Append(HorizontalLine);

            for (int j = 0; j <= 5; j++)
            {
                sb.Append(VerticalLineEnd);

                for (int i = 12; i < 24; i++)
                {
                    if (board[i].Count > j)
                    {
                        if (board[i].Color == eOccupiedColor.Black)
                        {
                            sb.Append(BlackCell);
                        }
                        else
                        {
                            sb.Append(WhiteCell);
                        }
                    }
                    else
                    {
                        sb.Append(EmptyCell);
                    }

                    if (i % 6 == 5)
                    {
                        sb.Append(VerticalLineEnd);
                    }
                    else
                    {
                        sb.Append(VerticalLine);
                    }
                }

                sb.Append(Environment.NewLine);
            }

            sb.Append(MiddleRow);

            for (int j = 5; j >= 0; j--)
            {
                sb.Append(VerticalLineEnd);

                for (int i = 11; i >= 0; i--)
                {
                    if (board[i].Count > j)
                    {
                        if (board[i].Color == eOccupiedColor.Black)
                        {
                            sb.Append(BlackCell);
                        }
                        else
                        {
                            sb.Append(WhiteCell);
                        }
                    }
                    else
                    {
                        sb.Append(EmptyCell);
                    }

                    if (i % 6 == 0)
                    {
                        sb.Append(VerticalLineEnd);
                    }
                    else
                    {
                        sb.Append(VerticalLine);
                    }
                }

                sb.Append(Environment.NewLine);
            }

            sb.Append(HorizontalLine);
            sb.Append(bottomRow);

            Console.WriteLine(sb.ToString());
        }

        public sMove GetMove()
        {
            string input = string.Empty;
            char[] splitBy = { ',' };
            string[] parsedInput = null;
            int die;
            int column;

            Console.WriteLine("please enter move in the format ‘x,y’ where x marks the number of colom from which to move or ‘in’ for re-entry of checker to game, and y marks the die used");

            while (true)
            {
                input = Console.ReadLine();
                parsedInput = input.Split(splitBy);

                if (parsedInput.Length == 2)
                {
                    if (parsedInput[0] == "in")
                    {
                        if (int.TryParse(parsedInput[1], out die) && die >= 1 && die <= 6)
                        {
                            return new sMove(null, die, eTypeOfMove.In);
                        }
                    }

                    if (int.TryParse(parsedInput[0], out column) && int.TryParse(parsedInput[1], out die))
                    {
                        if (column >= 1 && column <= 24 && die >= 1 && die <= 6)
                        {
                            return new sMove(column - 1, die, eTypeOfMove.Regular);
                        }
                    }

                    Console.WriteLine("invalid input, please enter a valid input");
                }
            }
        }

    }
}
