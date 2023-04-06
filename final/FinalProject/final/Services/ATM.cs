using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Casting;

namespace FinalProject.Services
{
    // This is the base class for the ATM. It defines basic functionality such as verifying the user
    // and displaying the main menu. The other classes will inherit from this one and add additional
    // functionality as needed.
    class ATM
    {
        // Private fields to store the user's card number and PIN
        private string cardNumber;
        private string pin;

        // Constructor that sets the card number and PIN
        public ATM(string cardNumber, string pin)
        {
            this.cardNumber = cardNumber;
            this.pin = pin;
        }

        // Method to verify the user's card number and PIN
        // Returns true if the card number and PIN are correct, false otherwise
        public bool VerifyUser(string cardNumber, string pin)
        {
            return this.cardNumber == cardNumber && this.pin == pin;
        }

        // Method to display the main menu
        public void DisplayMenu()
        {
            Console.WriteLine("Welcome to the ATM!");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Check balance");
            Console.WriteLine("2. Withdraw cash");
            Console.WriteLine("3. Deposit cash");
            Console.WriteLine("4. Exit");
        }

        // public void Withdraw(User user, decimal amount)
        // {
        //     if (!VerifyUser(user.ATMCard.GetCardNumber(), user.ATMCard.GetPin()))
        //     {
        //         Console.WriteLine("Invalid card number or PIN.");
        //         return;
        //     }

        //     if (user.BankAccount.Withdraw(amount))
        //     {
        //         Console.WriteLine("Withdrawal successful. Please take your cash.");
        //     }
        //     else
        //     {
        //         Console.WriteLine("Insufficient funds.");
        //     }
        // }


        public void Withdraw(User user, decimal amount)
        {
            if (!VerifyUser(user.ATMCard.GetCardNumber(), user.ATMCard.GetPin()))
            {
                Console.WriteLine("Invalid card number or PIN.");
                return;
            }

            BankAccount account = user.BankAccount;

            // bool success = account.Withdraw(amount);

            // if (success)
            // {
            //     Console.WriteLine("Withdrawal successful. Please take your cash.");
            // }
            // else
            // {
            //     Console.WriteLine("Insufficient funds.");
            // }
        }


        public void Deposit(User user, decimal amount)
        {
            if (!VerifyUser(user.ATMCard.GetCardNumber(), user.ATMCard.GetPin()))
            {
                Console.WriteLine("Invalid card number or PIN.");
                return;
            }

            user.BankAccount.Deposit(amount);
            Console.WriteLine("Deposit successful. Thank you for your business.");
        }
    }
}