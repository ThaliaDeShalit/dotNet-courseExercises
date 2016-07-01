using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountsLib;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Account acc = AccountFactory.CreateAccount(0);
            Account secondAcc;
            string input;
            double num;
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine(@"Hello, please choose by number an operation to preform:
1: Deposit money into account
2: Withdraw money from account
3: Get current balance of account
4: Exit");
                input = Console.ReadLine();

                while (input != "1" && input != "2" && input != "3" && input != "4")
                {
                    Console.WriteLine("Input not valid. Please enter the number corresponding with the operation you would like to perform");
                    input = Console.ReadLine();
                }

                switch (input)
                {
                    case "1":
                        try
                        {
                            acc.Deposit(GetAmountOfMoneyFromUser("Please enter the amount of money you would like to deposit"));

                            Console.WriteLine("The requested amount was deposited succesfully");
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            Console.WriteLine("Can not deposit negative amount");
                        }
                        break;
                    case "2":
                        try
                        {
                            acc.Withdraw(GetAmountOfMoneyFromUser("Please enter the amount of money you would like to withdraw"));

                            Console.WriteLine("The requested amount was deposited succesfully");
                        }
                        catch (InsufficientFundsException e)
                        {
                            Console.WriteLine("there is not enough money in the account to withdrew");
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            Console.WriteLine("Can not withdraw negative amount");
                        }
                        break;

                    case "3":
                        Console.WriteLine("The amount of money in account {0} is {1}", acc.ID, acc.Balance);

                        break;
                    case "4":
                        exit = true;
                        break;
                }

                Console.WriteLine();
            }

            secondAcc = AccountFactory.CreateAccount(0);

            Console.WriteLine("please enter amount to transfer from account {0} to account {1}", acc.ID, secondAcc.ID);
            input = Console.ReadLine();

            while (!double.TryParse(input, out num))
            {
                Console.WriteLine("Input not valid. Please enter a double");
                input = Console.ReadLine();
            }

            try
            {
                secondAcc.Transfer(acc, num);
            }
            catch (InsufficientFundsException e)
            {
                Console.WriteLine("there is not enough money in account {0} to withdrew", acc.ID);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Can not transfer negative amount");
            }
        }

        private static double GetAmountOfMoneyFromUser(string s)
        {
            string input;
            double num = 0;

            Console.WriteLine(s);
            input = Console.ReadLine();

            while (!double.TryParse(input, out num))
            {
                Console.WriteLine("Invalid input, please try again");
                input = Console.ReadLine();
            }

            return num;
        }
    }
}
