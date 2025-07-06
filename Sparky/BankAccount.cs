using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class BankAccount
    {
        public int balance { get; set; }
        private readonly ILogBook _logBook;

        public BankAccount(ILogBook logBook)
        { 
            _logBook = logBook;
            balance = 0;    
        
        }

        public BankAccount() {
            balance = 0;
        }
        public bool Deposit(int amount)
        {
            _logBook.Message("Deposit invoked"); //true
            _logBook.Message("Test"); //true
            _logBook.LogSeverity = 101;
            balance += amount;
            return true;
        }

        public bool WithDraw(int amount)
        {
            if (amount <= balance)
            {
                _logBook.LogToDB("Withdrawal Amount: " + amount.ToString());
                balance -= amount;
                return true;
            }
            return _logBook.LogBalanceAfterWithdrawal(balance-amount);
        
        }

        public int GetBalance() 
        {
            return balance;
        }

    }
}
