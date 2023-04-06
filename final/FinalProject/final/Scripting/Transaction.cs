using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace FinalProject.Scripting
{
    // This class represents a transaction. It has fields to store the transaction amount, type,
    // and date/time.
    class Transaction
    {
        // Private fields to store the transaction amount, type, and date/time
        private decimal amount;
        private string type;
        private DateTime dateTime;

        // Constructor that initializes the fields with the given values
        public Transaction(decimal amount, string type)
        {
            this.amount = amount;
            this.type = type;
            this.dateTime = DateTime.Now;
        }

        // Method to get the transaction amount
        public decimal GetAmount()
        {
            return this.amount;
        }

        // Method to get the transaction type
        public string GetTransactionType()
        {
            return this.type;
        }

        // Method to get the transaction date/time
        public DateTime GetDateTime()
        {
            return this.dateTime;
        }

        // Override of ToString method to print out the transaction details
        public override string ToString()
        {
            return $"Amount: {this.amount}, Type: {this.type}, Date/Time: {this.dateTime}";
        }
    }
}
