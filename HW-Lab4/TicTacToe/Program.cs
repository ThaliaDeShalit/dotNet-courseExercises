using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeGame game = new TicTacToeGame();
            string input;
            Coordinate c;

            game.DisplayBoard();

            while (!game.IsGameOver)
            {
                Console.WriteLine("please enter a move in the following format: x,y");
                input = Console.ReadLine();

                while (!Coordinate.TryParse(input, out c))
                {
                    Console.WriteLine("invalid format, please enter in the following format: x,y");
                    input = Console.ReadLine();
                }

                while (!game.TrySetMove(c))
                {
                    Console.WriteLine("move is not valid, please make sure to choose both x and y coordinates to be between 1-3, and that the cell is not occupied");
                    input = Console.ReadLine();

                    while (!Coordinate.TryParse(input, out c))
                    {
                        Console.WriteLine("invalid format, please enter in the following format: x,y");
                        input = Console.ReadLine();
                    }
                }

                game.DisplayBoard();
            }
        }
    }
}
