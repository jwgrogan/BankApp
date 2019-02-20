using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankApp
{
    static class Bank
    {
        private static List<Account> accounts = new List<Account>();
        private static List<Transaction> transactions = new List<Transaction>();
        
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

            accounts.Add(account);
            return account;
        }

        public static IEnumerable<Account> GetAllAccounts(string emailAddress)
        {
            return accounts.Where(account => account.EmailAddress == emailAddress);
                
         }

        public static IEnumerable<Transaction> GetAllTransactions(int accountNumber)
        {
            return transactions.Where(transaction => transaction.Account.AccountNumber == accountNumber).OrderByDescending(collumn => collumn.TransactionDate);
        }

        public static void Deposit(int accountNumber, decimal amount)
        {
            var account = accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
                return;

            account.Deposit(amount);

            var transaction = new Transaction
            {
                TransactionAmount = amount,
                Description = "Deposited through the bank",
                TransactionType = TransactionType.Credit,
                TransactionDate = DateTime.UtcNow,
                Account = account
            };

            transactions.Add(transaction);
        }

        public static void Withdraw(int accountNumber, decimal amount)
        {
            var account = accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
                return;

            account.Withdraw(amount);

            var transaction = new Transaction
            {
                TransactionAmount = amount,
                Description = "Withdrawal through the bank",
                TransactionType = TransactionType.Debit,
                TransactionDate = DateTime.UtcNow,
                Account = account
            };

            transactions.Add(transaction);
        }

    }
}
