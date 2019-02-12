using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("*******************************");
            Console.WriteLine("Welcome to the bank!");

            while (true)
            {
                
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Create an account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Print all accounts");
            Console.WriteLine("5. Print all transactions");

            var option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting the bank!");
                        return;
                    case "1":
                        Console.Write("Account Name:");
                        var accountName = Console.ReadLine();
                        Console.Write("Email Address:");
                        var emailAddress = Console.ReadLine();
                        Console.Write("Initial Deposit: ");
                        var deposit = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Type of Account:");
                        var accountTypes = Enum.GetNames(typeof(TypeOfAccount));
                        for (var i = 0; i < accountTypes.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}. {accountTypes[i]}");
                        }
                        var accountType = Enum.Parse<TypeOfAccount>(Console.ReadLine()) - 1; 
                   
                        var myAccount = Bank.CreateAccount(accountName, emailAddress, accountType, deposit);
                        Console.WriteLine($"Account Number: {myAccount.AccountNumber}, Account Name: {myAccount.AccountName} Balance: {myAccount.Balance}, " +
                            $"Account Type: {myAccount.AccountType}, Date Created: {myAccount.CreateDate},");
                        break;

                    case "2":
                        PrintAllAccounts();
                        Console.Write("Account Number: ");
                        var accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to deposit:");
                        var amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Deposit(accountNumber, amount);
                        break;

                    case "3":
                        PrintAllAccounts();

                        break;

                    case "4":
                        PrintAllAccounts();

                        break;
                    case "5":
                        PrintAllAccounts();
                        Console.Write("Account number:");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        var transations = Bank.GetAllTransactions(accountNumber);
                        foreach (var transaction in transactions) ;
                        {
                            Console.WriteLine($"TD: {transaction.TransactionDate}, TA: {transaction.TransactionAmount}, TT: {transaction.TransactionType}");
                        }

                        break;
                    default:
                        break;
                }
               
            }
      
           
        }

        private static void PrintAllAccounts()
        {
         
            Console.Write("Email Address: ");
            var emailAddress = Console.ReadLine();
            var accounts = Bank.GetAllAccounts(emailAddress);
            foreach (var account in accounts)
            {
                Console.WriteLine($"Account Number: {account.AccountNumber}, Account Name: {account.AccountName} Balance: {account.Balance}, " +
                $"Account Type: {account.AccountType}, Date Created: {account.CreateDate},");
            }

            
        }
    }
}
