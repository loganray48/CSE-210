using System.Collections.Generic;
using FinalProject.Casting;
using FinalProject.Services;
using FinalProject.Scripting;

namespace FinalProject.Directing
{
    public class Director
    {
        public Director()
        {
        }

        // Create an instance of a User
        public User CreateUser(string name, string email, string phoneNumber, string address, decimal balance, decimal savingsBalance)
        {
            BankAccount bankAccount = new SavingsAccount(balance, savingsBalance);
            ATMCard atmCard = new ATMCard("1234567890", "1234");
            atmCard.SetBankAccount(bankAccount);
            User user = new User(name, email, phoneNumber, address, bankAccount, atmCard);
            return user;
        }
        // Perform a deposit transaction for the given user
        public void Deposit(User user, decimal amount)
        {
            ATM atm = new ATM(user.ATMCard.GetCardNumber(), user.ATMCard.GetPin());
            atm.Deposit(user, amount);
        }

        // Perform a withdrawal transaction for the given user
        public void Withdraw(User user, decimal amount)
        {
            ATM atm = new ATM(user.ATMCard.GetCardNumber(), user.ATMCard.GetPin());
            atm.Withdraw(user, amount);
        }

        // Get the transaction history for the given user
        public List<TransactionRecord> GetTransactionHistory(User user)
        {
            List<TransactionRecord> transactionHistory = new List<TransactionRecord>();
            decimal currentBalance = user.BankAccount.GetBalance();
            foreach (var transaction in user.BankAccount.GetTransactions())
            {
                TransactionRecord transactionRecord = new TransactionRecord(transaction.TransactionType, transaction.TransactionAmount, currentBalance)
                {
                    TransactionDateTime = transaction.TransactionDateTime
                };
                transactionHistory.Add(transactionRecord);
                currentBalance -= transaction.TransactionAmount;
            }
            return transactionHistory;
        }

        // Dispense an ATM card to the user
        public void DispenseCash(decimal amount, BankAccount bankAccount)
        {
            CardDispenser dispenser = new CardDispenser();
            dispenser.DispenseCash(amount, bankAccount);
        }
    }
}
