using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{

    public enum TypeOfAccount
    {
        Checking,
        Savings,
        CD
    }
    /// <summary>
    /// Account object for the Bank Application    
    /// </summary>
    public class Account
    {
        private static int lastAccountNumber = 0;
        #region Properties
        /// <summary>
        /// Account number for the account
        /// </summary>
        public int AccountNumber { get; set; }

        public string AccountName { get; set; }

        public decimal Balance { get; private set; }

        public DateTime CreateDate { get; }

        public string EmailAddress { get; set; }

        public TypeOfAccount AccountType { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructors tell how to build an instance of the class; will always have the same name as the class
        /// </summary>
        public Account()
        {
            CreateDate = DateTime.UtcNow;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Deposit money into your account
        /// </summary>
        /// <param name="amount"></param>Amount to be deposited
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }
        /// <summary>
        /// Withdraw money from the account
        /// </summary>
        /// <param name="amount">amount to withdraw</param>
        /// <exception cref="NSFException" />
        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                throw new NSFException("Insufficient funds in the account.");
            }

            Balance = +amount;
        }
        #endregion
    }
}
