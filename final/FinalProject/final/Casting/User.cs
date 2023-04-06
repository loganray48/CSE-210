using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Scripting;

namespace FinalProject.Casting
{
    public class User
    {
        // Encapsulated fields
        private string name;
        private string email;
        private string phoneNumber;
        private string address;
        private BankAccount bankAccount;
        private ATMCard atmCard;

        // Constructor
        public User(string name, string email, string phoneNumber, string address, BankAccount bankAccount, ATMCard atmCard)
        {
            this.name = name;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.bankAccount = bankAccount;
            this.atmCard = atmCard;
        }



        // Getters and setters
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public BankAccount BankAccount
        {
            get { return bankAccount; }
            set { bankAccount = value; }
        }

        public ATMCard ATMCard
        {
            get { return atmCard; }
            set { atmCard = value; }
        }

        // Method to display user information
        public void DisplayUserInfo()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Email: " + email);
            Console.WriteLine("Phone Number: " + phoneNumber);
            Console.WriteLine("Address: " + address);
            Console.WriteLine("Bank Account Number: " + bankAccount.AccountNumber);
            Console.WriteLine("ATM Card Number: " + atmCard.GetCardNumber());
        }
    }
}
