using System;
using FinalProject.Directing;

namespace FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccountManager bankManager = new BankAccountManager();
            string currentAccountNumber = null;

            while (true)
            {
                if (currentAccountNumber == null)
                {
                    Console.WriteLine("Enter 'login' to login or 'create' to create a new account:");
                    string choice = Console.ReadLine().ToLower();

                    if (choice == "login")
                    {
                        Console.Write("Enter account number: ");
                        string accountNumber = Console.ReadLine();
                        Console.Write("Enter PIN: ");
                        string pin = Console.ReadLine();

                        if (bankManager.Login(accountNumber, pin))
                        {
                            Console.WriteLine("Login successful.");
                            currentAccountNumber = accountNumber;
                        }
                        else
                        {
                            Console.WriteLine("Login failed. Please try again.");
                        }
                    }
                    else if (choice == "create")
                    {
                        Console.Write("Enter name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter email: ");
                        string email = Console.ReadLine();
                        Console.Write("Enter phone number: ");
                        string phoneNumber = Console.ReadLine();
                        Console.Write("Enter address: ");
                        string address = Console.ReadLine();
                        Console.Write("Enter initial account balance: ");
                        decimal balance = decimal.Parse(Console.ReadLine());
                        Console.Write("Enter initial savings balance: ");
                        decimal savingsBalance = decimal.Parse(Console.ReadLine());

                        (string accountNumber, string pin) = bankManager.CreateAccount(name, email, phoneNumber, address, balance, savingsBalance);
                        Console.WriteLine($"Account created. Account Number: {accountNumber}, PIN: {pin}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please try again.");
                    }
                }
                else
                {
                    // Console.WriteLine("Enter 'deposit' to deposit funds, 'withdraw' to withdraw funds, 'transaction' to view transaction history, or 'quit' to exit:");
                    // string choice = Console.ReadLine().ToLower();
                    Console.WriteLine("Enter 'deposit' to deposit funds, 'withdraw' to withdraw funds, or 'quit' to exit:");
                    string choice = Console.ReadLine().ToLower();

                    if (choice == "deposit")
                    {
                        Console.Write("Enter deposit amount: ");
                        decimal amount = decimal.Parse(Console.ReadLine());
                        bankManager.Deposit(currentAccountNumber, amount);
                        
                    }
                    else if (choice == "withdraw")
                    {
                        Console.Write("Enter withdrawal amount: ");
                        decimal amount = decimal.Parse(Console.ReadLine());
                        bankManager.Withdraw(currentAccountNumber, amount);
                    }
                    else if (choice == "transaction")
                    {
                        bankManager.PrintTransactionHistory(currentAccountNumber); // fixed variable name

                    }
                    else if (choice == "quit")
                    {
                        Console.WriteLine("Goodbye!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please try again.");
                    }
                }
            }
        }
    }
}