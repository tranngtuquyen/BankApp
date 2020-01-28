using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankApp
{
    static class Bank
    {
        private static List<Account> accounts = new List<Account>();

        /// <summary>
        /// Creates an account in the bank
        /// </summary>
        /// <param name="accountName">Name of account</param>
        /// <param name="emailAddress">Email address associated with the account</param>
        /// <param name="accountType">Type of account</param>
        /// <param name="initialDeposit">Initial deposit</param>
        /// <returns>Newly created account</returns>
        public static Account CreateAccount(string accountName, string emailAddress, TypeOfAccounts accountType = TypeOfAccounts.Checking, decimal initialDeposit = 0)
        {
            var account = new Account
            {
                AccountName = accountName,
                EmailAddress = emailAddress,
                AccountType = accountType
            };
            
            if (initialDeposit > 0)
            {
                account.Deposit(initialDeposit);
            }

            accounts.Add(account);

            return account;
        }

        public static void Deposit(int accountNumber, decimal amount)
        {
            var account = accounts.Where<Account>(a => a.AccountNumber == accountNumber);
        }
    }
}
