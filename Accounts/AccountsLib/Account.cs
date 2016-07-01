using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsLib
{
    public class Account
    {
        private int _ID;
        private double _Balance;

        internal Account(int id)
        {
            _ID = id;
            Balance = 0;
        }

        public int ID
        {
            get
            {
                return _ID;
            }
        }

        public double Balance
        {
            get
            {
                return _Balance;
            }
            set
            {
                _Balance = value;
            }

        }

        public void Deposit(double amountToDeposit)
        {
            if (amountToDeposit < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                Balance += amountToDeposit;
            }
        }

        public void Withdraw(double amountToWithdrew)
        {
            if (amountToWithdrew < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                if ((Balance - amountToWithdrew) >= 0)
                {
                    Balance -= amountToWithdrew;
                }
                else
                {
                    throw new InsufficientFundsException();
                }
            }
        }

        public void Transfer(Account acountToWithdrewFrom, double amountToWithdrew)
        {
            double balanceBeforeTransferAttempt = Balance;

            try
            {
                if (amountToWithdrew <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                acountToWithdrewFrom.Withdraw(amountToWithdrew);
                Deposit(amountToWithdrew);
            }
            finally
            {
                Console.WriteLine("A transfer attempt from account {0} to account {1} has been made", acountToWithdrewFrom.ID, ID);
                Console.WriteLine("Amount of money in account {0} before the transfer was {1}, and after it was {2}", ID, balanceBeforeTransferAttempt, Balance);

            }
        }
    }
}
