using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Casting;


namespace FinalProject.Services
{
    public class CardDispenser
    {
        private const int MaxBills = 100;
        private int[] bills = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };

        public bool DispenseCash(decimal amount, BankAccount account)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid amount entered.");
                return false;
            }

            if (amount % 20 != 0)
            {
                Console.WriteLine("Amount must be a multiple of 20.");
                return false;
            }

            if (amount > account.Balance)
            {
                Console.WriteLine("Insufficient funds.");
                return false;
            }

            int[] tempBills = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            int total = 0;
            for (int i = 0; i < bills.Length; i++)
            {
                int billValue = (i + 1) * 20;
                while (bills[i] > 0 && total + billValue <= amount)
                {
                    tempBills[i]++;
                    bills[i]--;
                    total += billValue;
                }

                if (total == amount)
                {
                    Console.WriteLine($"Dispensed {amount} from your account.");
                    account.Withdraw(amount);
                    Console.WriteLine("Please take your money from below.");
                    return true;
                }
            }

            Console.WriteLine("Unable to dispense cash at this time. Please try again later.");
            return false;
        }

        public void Restock()
        {
            bills = new int[] { MaxBills, MaxBills, MaxBills, MaxBills, MaxBills, MaxBills, MaxBills, MaxBills };
            Console.WriteLine("Cash dispenser restocked.");
        }
    }
}



