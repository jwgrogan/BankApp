using Microsoft.EntityFrameworkCore;
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
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Bank2019;Integrated Security=True;Connect Timeout=30;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Accounts");

                entity.HasKey(akey => akey.AccountNumber);

                entity.Property(a => a.AccountNumber).ValueGeneratedOnAdd();

                entity.Property(a => a.EmailAddress).IsRequired().HasMaxLength(50);

                entity.Property(a => a.AccountType).IsRequired();

                entity.Property(a => a.AccountName).HasMaxLength(50);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transactions");

                entity.HasKey(tkey => tkey.TransactionId);

                entity.Property(t => t.TransactionId).ValueGeneratedOnAdd();
            });

        }
    }
}
