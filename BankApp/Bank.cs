using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankApp
{
    static class Bank
    {
        private static BankModel db = new BankModel();
        
        public static Account CreateAccount(string accountName, string emailAddress,
            TypeOfAccount accountType = TypeOfAccount.Checking, decimal initialDeposit = 0)
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

            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }

        public static IEnumerable<Account> GetAllAccounts(string emailAddress)
        {
            return db.Accounts.Where(account => account.EmailAddress == emailAddress);
                
         }

        public static IEnumerable<Transaction> GetAllTransactions(int accountNumber)
        {
            return db.Transactions.Where(transaction => transaction.Account.AccountNumber == accountNumber).OrderByDescending(collumn => collumn.TransactionDate);
        }

        public static void Deposit(int accountNumber, decimal amount)
        {
            var account = db.Accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
                throw new ArgumentOutOfRangeException("accountNumber", "Invalid account number");

            account.Deposit(amount);

            var transaction = new Transaction
            {
                TransactionAmount = amount,
                Description = "Deposited through the bank",
                TransactionType = TransactionType.Credit,
                TransactionDate = DateTime.UtcNow,
                Account = account
            };

            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        public static void Withdraw(int accountNumber, decimal amount)
        {
            var account = db.Accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
                throw new ArgumentOutOfRangeException("accountNumber", "Invalid account number");

            account.Withdraw(amount);

            var transaction = new Transaction
            {
                TransactionAmount = amount,
                Description = "Withdrawal through the bank",
                TransactionType = TransactionType.Debit,
                TransactionDate = DateTime.UtcNow,
                Account = account
            };

            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

    }
}
