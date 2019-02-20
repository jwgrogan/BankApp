﻿// <auto-generated />
using System;
using BankApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BankApp.Migrations
{
    [DbContext(typeof(BankModel))]
    [Migration("20190220194142_Migration2")]
    partial class Migration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BankApp.Account", b =>
                {
                    b.Property<int>("AccountNumber")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountName")
                        .HasMaxLength(50);

                    b.Property<int>("AccountType");

                    b.Property<decimal>("Balance");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("AccountNumber");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BankApp.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountNumber");

                    b.Property<string>("Description");

                    b.Property<decimal>("TransactionAmount");

                    b.Property<DateTime>("TransactionDate");

                    b.Property<int>("TransactionType");

                    b.HasKey("TransactionId");

                    b.HasIndex("AccountNumber");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("BankApp.Transaction", b =>
                {
                    b.HasOne("BankApp.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountNumber");
                });
#pragma warning restore 612, 618
        }
    }
}