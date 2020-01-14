using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var myAccount = new Account();
            myAccount.AccountNumber = 123456;
            myAccount.Deposit(1000);
            Console.WriteLine($"Account Number: {myAccount.AccountNumber}, Balance: {myAccount.Balance}");
        }
    }
}
