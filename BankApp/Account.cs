using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    public enum TypeOfAccounts
    {
        Checking,
        Saving,
        CD,
        Loan
    }

    /// <summary>
    /// This represents a bank account 
    /// where you could withdraw or deposit money into the account
    /// </summary>
    public class Account
    {
        #region Properties
        public int AccountNumber { get; private set; }
        public string AccountName { get; set; }
        public TypeOfAccounts AccountType { get; set; }
        public decimal Balance { get; private set; }
        public string EmailAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        #endregion
        #region Constructor
        public Account()
        {
            CreatedDate = DateTime.UtcNow;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Deposit money into account
        /// </summary>
        /// <param name="amount">Amount to deposit</param>
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }
        /// <summary>
        /// Withdraw money from account
        /// </summary>
        /// <param name="amount">Amount to withdraw</param>
        /// <returns></returns>
        public decimal Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                throw new ArgumentOutOfRangeException("amount", "InSufficient funds!");
            }
            Balance -= amount;
            return Balance;
        }
        #endregion
    }
}
