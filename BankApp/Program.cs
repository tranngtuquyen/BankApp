using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var myAccount = Bank.CreateAccount("Account1", "test@test.com", TypeOfAccounts.Loan, 1000);
            Console.WriteLine($"Account Number: {myAccount.AccountNumber}, Email: {myAccount.EmailAddress}, Account Type: {myAccount.AccountType}, Balance: {myAccount.Balance}, Date: {myAccount.CreatedDate}");

            var myAccount2 = Bank.CreateAccount("Account2", "test2@test.com", initialDeposit: 2000);
            Console.WriteLine($"Account Number: {myAccount2.AccountNumber}, Email: {myAccount2.EmailAddress}, Account Type: {myAccount2.AccountType}, Balance: {myAccount2.Balance}, Date: {myAccount2.CreatedDate}");
        }
    }
}
