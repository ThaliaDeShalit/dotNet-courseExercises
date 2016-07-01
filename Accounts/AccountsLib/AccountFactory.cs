using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsLib
{
    public static class AccountFactory
    {
        private static int id = 1;
        
        public static Account CreateAccount(double initialBalance)
        {
            Account account = new Account(id++);

            account.Deposit(initialBalance);

            return account;
        }

    }
}
