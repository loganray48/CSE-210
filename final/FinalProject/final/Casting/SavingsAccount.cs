using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Casting
{
    // Inherit from the BankAccount class
    public class SavingsAccount : BankAccount
    {
        // Private field for savings balance
        private decimal savingsBalance;

        // Constructor that sets the balance and savings balance
        public SavingsAccount(decimal balance, decimal savingsBalance) : base()
        {
            this.Balance = balance;
            this.savingsBalance = savingsBalance;
        }

        // Public property for savings balance
        public decimal SavingsBalance
        {
            get { return savingsBalance; }
            set { savingsBalance = value; }
        }

        // Method that rounds up the transaction amount to the nearest dollar and transfers the rounded up amount to savings
        public bool RoundUpToSavings(decimal transactionAmount)
        {
            // Round up the transaction amount to the nearest dollar
            decimal roundedAmount = Math.Ceiling(transactionAmount);

            // Check if the rounded amount is greater than the transaction amount and there is enough balance to transfer the difference
            if (roundedAmount > transactionAmount && Balance >= (roundedAmount - transactionAmount))
            {
                // Add the difference to savings balance and subtract it from the account balance
                SavingsBalance += (roundedAmount - transactionAmount);
                Balance -= (roundedAmount - transactionAmount);
                return true;
            }

            return false;
        }

        // Method that withdraws the given amount from savings balance
        public override void Withdraw(decimal amount)
        {
            if (Balance - amount >= 100)
            {
                Balance -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
            }
        }
    }
}

