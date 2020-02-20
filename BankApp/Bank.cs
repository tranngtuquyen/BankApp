using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankApp
{
    static class Bank
    {
        private static BankContext db = new BankContext();
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

            db.Accounts.Add(account);
            db.SaveChanges();

            if (initialDeposit > 0)
            {
                account.Deposit(initialDeposit);
                db.SaveChanges();
                CreateTransaction(initialDeposit, account.AccountNumber, TypeOfTransaction.Credit, "Initial Deposit");
            }

            return account;
        }

        public static void Deposit(int accountNumber, decimal amount)
        {
            var account = db.Accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                throw new ArgumentException("Invalid account number. Try again!");
            }

            account.Deposit(amount);
            CreateTransaction(amount, accountNumber, TypeOfTransaction.Credit, "Bank Deposit");
            db.SaveChanges();
        }

        /// <summary>
        /// Withdraw money from the account
        /// </summary>
        /// <param name="accountNumber">Account number</param>
        /// <param name="amount">Amount to withdraw</param>
        /// <exception cref="ArgumentException" />
        public static void Withdraw(int accountNumber, decimal amount)
        {
            var account = db.Accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                throw new ArgumentException("Invalid account number. Try again!");
            }

            account.Withdraw(amount);
            CreateTransaction(amount, accountNumber, TypeOfTransaction.Debit, "Bank Withdraw");
            db.SaveChanges();
        }

        public static IEnumerable<Account> GetAllAccountsByEmailAddress(string emailAddress)
        {
            return db.Accounts.Where(a => a.EmailAddress == emailAddress);
        }

        public static IEnumerable<Transaction> GetAllTransactionsByAccountNumber(int accountNumber)
        {
            return db.Transactions.Where(t => t.AccountNumber == accountNumber).OrderByDescending(t => t.TransactionDate);
        }

        private static void CreateTransaction(decimal amount, int accountNumber, TypeOfTransaction transactionType, string description = "")
        {
            var transaction = new Transaction
            {
                TransactionDate = DateTime.UtcNow,
                Amount = amount,
                AccountNumber = accountNumber,
                TransactionType = transactionType,
                Description = description
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }
    }
}
