using System;
using System.Collections.Generic;
using System.IO;
using FinalProject.Casting;
using FinalProject.Services;
using FinalProject.Scripting;

namespace FinalProject.Directing
{
    public class BankAccountManager
    {
        private Dictionary<string, User> _users;

        public BankAccountManager()
        {
            _users = new Dictionary<string, User>();

            // Load data from the CSV file
            using (var reader = new StreamReader("users.csv"))
            {
                string headerLine = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] fields = line.Split(',');
                    string accountNumber = fields[0];
                    string name = fields[1];
                    string email = fields[2];
                    string phoneNumber = fields[3];
                    string address = fields[4];
                    decimal balance = decimal.Parse(fields[5]);
                    decimal savingsBalance = decimal.Parse(fields[6]);
                    string pin = fields[7];

                    // Create a new user
                    User newUser = new Director().CreateUser(name, email, phoneNumber, address, balance, savingsBalance);
                    newUser.ATMCard = new ATMCard(pin, "");
                    _users.Add(accountNumber, newUser);
                }
            }
        }


        // Create a new user account
        public (string, string) CreateAccount(string name, string email, string phoneNumber, string address, decimal balance, decimal savingsBalance)
        {
            // Generate a new account number
            string accountNumber = Guid.NewGuid().ToString().Substring(0, 8);

            // Generate a new PIN
            string pin = new Random().Next(1000, 9999).ToString();

            // Create a new user
            User newUser = new Director().CreateUser(name, email, phoneNumber, address, balance, savingsBalance);
            newUser.ATMCard = new ATMCard(pin, "");

            // Add the new user to the dictionary of users
            _users.Add(accountNumber, newUser);

            // Write the new user data to the file
            using (var writer = new StreamWriter("users.csv", true))
            {
                writer.WriteLine($"{accountNumber},{name},{email},{phoneNumber},{address},{balance},{savingsBalance},{pin}");
            }

            return (accountNumber, pin);
        }

        // Login to an existing user account
        public bool Login(string accountNumber, string pin)
        {
            // Check if the accountNumber and pin match any accounts in the CSV file
            LoginService loginService = new LoginService();
            bool loginSuccessful = loginService.Login(accountNumber, pin);

            if (loginSuccessful)
            {
                Console.WriteLine("Login successful.");
                return true;
            }
            else
            {
                Console.WriteLine("Incorrect account number or PIN.");
                return false;
            }
        }


        // Perform a deposit transaction for the given user
        public void Deposit(string accountNumber, decimal amount)
        {
            if (!_users.ContainsKey(accountNumber))
            {
                Console.WriteLine("Account not found.");
                return;
            }

            User user = _users[accountNumber];
            new Director().Deposit(user, amount);

            // Read in the existing data from the CSV file
            string[] lines = File.ReadAllLines("users.csv");

            // Find the row corresponding to the user's account number and update the balance
            for (int i = 1; i < lines.Length; i++) // start at i=1 to skip header row
            {
                string[] fields = lines[i].Split(',');
                string lineAccountNumber = fields[0];
                if (lineAccountNumber == accountNumber)
                {
                    decimal balance = decimal.Parse(fields[5]) + amount;
                    string updatedLine = $"{fields[0]},{fields[1]},{fields[2]},{fields[3]},{fields[4]},{balance},{fields[6]},{fields[7]}";
                    lines[i] = updatedLine;
                    break;
                }
            }

            // Write the updated data back to the CSV file
            File.WriteAllLines("users.csv", lines);

            Console.WriteLine("Deposit successful.");
        }

        // Perform a withdrawal transaction for the given user
        public void Withdraw(string accountNumber, decimal amount)
        {
            if (!_users.ContainsKey(accountNumber))
            {
                Console.WriteLine("Account not found.");
                return;
            }

            User user = _users[accountNumber];
            new Director().Withdraw(user, amount);

            // Read in the existing data from the CSV file
            string[] lines = File.ReadAllLines("users.csv");

            // Find the row corresponding to the user's account number and update the balance
            for (int i = 1; i < lines.Length; i++) // start at i=1 to skip header row
            {
                string[] fields = lines[i].Split(',');
                string lineAccountNumber = fields[0];
                if (lineAccountNumber == accountNumber)
                {
                    decimal balance = decimal.Parse(fields[5]) - amount;
                    if (balance < 0)
                    {
                        Console.WriteLine("Insufficient funds.");
                        return;
                    }
                    string updatedLine = $"{fields[0]},{fields[1]},{fields[2]},{fields[3]},{fields[4]},{balance},{fields[6]},{fields[7]}";
                    lines[i] = updatedLine;
                    break;
                }
            }

            // Write the updated data back to the CSV file
            File.WriteAllLines("users.csv", lines);

            Console.WriteLine("Withdrawal successful.");
        }


        public void PrintTransactionHistory(string accountNumber)
        {
            if (!_users.ContainsKey(accountNumber))
            {
                Console.WriteLine("Account not found.");
                return;
            }

            string fileName = $"{accountNumber}_transactions.csv";
            if (!File.Exists(fileName))
            {
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    sw.WriteLine("Transaction Type,Amount,Date");
                }
            }

            // Read in the transaction history from the CSV file
            string[] lines = File.ReadAllLines(fileName);

            Console.WriteLine($"Transaction history for account {accountNumber}:");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }


        // Save the current list of users to a CSV file
        private void SaveUsersToCsv()
        {
            // Initialize a counter for skipping the header line when reading and writing the CSV file
            int i = 0;

            // Read the existing data from the CSV file and store unique lines in a HashSet
            HashSet<string> uniqueLines = new HashSet<string>();
            if (File.Exists("users.csv"))
            {
                using (StreamReader reader = new StreamReader("users.csv"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Skip the first line (header)
                        if (i == 0)
                        {
                            i++;
                            continue;
                        }

                        // Add the line to the HashSet if it's not already there
                        if (!uniqueLines.Contains(line))
                        {
                            uniqueLines.Add(line);
                        }
                    }
                }
            }

            // Add the new users to the HashSet
            foreach (var user in _users.Values)
            {
                string line = $"{user.BankAccount.GetAccountNumber()},{user.Name},{user.Email},{user.PhoneNumber},{user.Address},{user.BankAccount.GetBalance()},{((SavingsAccount)user.BankAccount).SavingsBalance},{user.ATMCard.GetPin()}";
                if (!uniqueLines.Contains(line))
                {
                    uniqueLines.Add(line);
                }
            }

            // Write the updated data back to the CSV file
            using (StreamWriter writer = new StreamWriter("users.csv"))
            {
                // Write the header line
                writer.WriteLine("Account Number,Name,Email,Phone Number,Address,Balance,Savings Balance,PIN");

                // Write the unique lines
                foreach (string line in uniqueLines)
                {
                    writer.WriteLine(line);
                }
            }
        }
    }
}
