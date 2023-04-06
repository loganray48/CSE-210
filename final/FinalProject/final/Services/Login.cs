using System;
using System.IO;
using System.Linq;

namespace FinalProject.Services
{
    public class LoginService
    {
        private const string CsvFilePath = "users.csv";

        public bool Login(string accountNumber, string pin)
        {
            try
            {
                var lines = File.ReadAllLines(CsvFilePath).Skip(1); // Skip header line
                foreach (var line in lines)
                {
                    var fields = line.Split(',');
                    if (fields[0] == accountNumber && fields[7] == pin)
                    {
                        // Account and PIN match
                        return true;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("CSV file not found.");
            }

            // No matching account and PIN found
            return false;
        }
    }
}