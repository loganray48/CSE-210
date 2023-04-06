using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace FinalProject.Scripting
{
    public class TransactionRecord
    {
        // fields
        private string transactionType;
        private decimal transactionAmount;
        private DateTime transactionDateTime;
        private decimal balance;

        // properties
        public string TransactionType
        {
            get { return transactionType; }
            set { transactionType = value; }
        }

        public decimal TransactionAmount
        {
            get { return transactionAmount; }
            set { transactionAmount = value; }
        }

        public DateTime TransactionDateTime
        {
            get { return transactionDateTime; }
            set { transactionDateTime = value; }
        }

        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        // constructor
        public TransactionRecord(string transactionType, decimal transactionAmount, decimal balance)
        {
            this.transactionType = transactionType;
            this.transactionAmount = transactionAmount;
            this.transactionDateTime = DateTime.Now;
            this.balance = balance;
        }

        // methods
        public void PrintTransaction()
        {
            Console.WriteLine("Transaction Type: {0}", transactionType);
            Console.WriteLine("Transaction Amount: {0:C}", transactionAmount);
            Console.WriteLine("Transaction Date and Time: {0}", transactionDateTime.ToString());
            Console.WriteLine("Balance: {0:C}", balance);
            Console.WriteLine();
        }
    }
}
