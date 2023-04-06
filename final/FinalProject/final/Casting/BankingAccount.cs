// Import necessary namespaces
using System;
using System.Collections.Generic;
using FinalProject.Scripting;
using FinalProject.Services;

namespace FinalProject.Casting
{
    public class BankAccount
    {
        // Declare static variable to keep track of next account number
        private static int NextAccountNumber = 1;

        // Declare instance variables
        private readonly int accountNumber;
        private decimal balance { get; set; }
        private List<TransactionRecord> transactions;

        // Constructor method
        public BankAccount()
        {
            // Set account number and increment NextAccountNumber
            this.accountNumber = NextAccountNumber;
            NextAccountNumber++;

            // Set initial balance to zero and initialize transactions list
            this.balance = 0m;
            this.transactions = new List<TransactionRecord>();
        }

        // AccountNumber property - read only
        public int AccountNumber
        {
            get { return accountNumber; }
        }

        // Balance property - read and write
        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        // Deposit method - adds the given amount to the balance and creates a transaction record

        // public void Deposit(decimal amount)
        // {
        //     this.Balance += amount;
        //     this.transactions.Add(new TransactionRecord("Deposit", amount, this.balance));
        // }

        // Withdraw method - subtracts the given amount from the balance if possible and creates a transaction record
        // Returns true if successful, false if insufficient funds
        // public bool Withdraw(decimal amount)
        // {
        //     if (this.Balance >= amount)
        //     {
        //         this.Balance -= amount;
        //         this.transactions.Add(new TransactionRecord("Withdrawal", amount, this.balance));
        //         return true;
        //     }
        //     else
        //     {
        //         return false;
        //     }
        // }

        public virtual void Withdraw(decimal amount)
        {
            Balance -= amount;
        }

        public virtual void Deposit(decimal amount)
        {
            Balance += amount;
        }


        // GetBalance method - returns the current balance
        public decimal GetBalance()
        {
            return this.Balance;
        }

        // GetTransactions method - returns a list of transaction records
        public List<TransactionRecord> GetTransactions()
        {
            return this.transactions;
        }

        // GetAccountNumber method - returns the account number
        public int GetAccountNumber()
        {
            return this.AccountNumber;
        }
    }
}
