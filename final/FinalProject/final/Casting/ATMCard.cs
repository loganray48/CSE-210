using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Casting
{
    // This class represents an ATM card. It has fields to store the card number and PIN.
    // It also has a field to store the associated bank account object, and methods to get
    // and set this field.
    public class ATMCard
    {
        // Private fields to store the card number and PIN
        private string cardNumber;
        private string pin;

        // Private field to store the associated bank account object
        private BankAccount bankAccount;

        // Constructor that initializes the fields with the given values
        public ATMCard(string cardNumber, string pin)
        {
            this.cardNumber = cardNumber;
            this.pin = pin;
        }

        // Method to get the card number
        public string GetCardNumber()
        {
            return this.cardNumber;
        }

        public string GetPin()
        {
            return this.pin;
        }

        // Method to set the associated bank account object
        public void SetBankAccount(BankAccount account)
        {
            this.bankAccount = account;
        }

        // Method to get the associated bank account object
        public BankAccount GetBankAccount()
        {
            return this.bankAccount;
        }

        // Method to check if the given PIN is correct
        public bool VerifyPIN(string pin)
        {
            return this.pin == pin;
        }
    }
}


