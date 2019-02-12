using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    class BankModel : DbContext

    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Bank2019; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        }  
        protected override void OnMOdelCreating(ModelBUilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.toTable("Accounts");
                entity.HasKey(async => async.accountNumber);

                entity.Property(a => a.AccountNumber).ValueGenerateOnAdd();
                entity.Property(a => async.EmailAddress).IsRequired().HasMaxLength(50);
                entity.Property(a => a.AccountType).IsRquired();
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transactions");
                entity.HasKey(t => t.TransactionId);

                entity.Property(t => t.TransactionId).ValueGeneratedOnAdd();
            });
        }
    }
}
