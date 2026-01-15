using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//5. Resource Management: Ensuring proper release of resources like file handles, database connections etc. using finally block or using statement.
//6. API Calls: Handling exceptions when calling external APIs or services.
//7. Multithreading: Handling exceptions in multi-threaded applications to prevent crashes and ensure thread safety.
//8. Configuration Management: Handling exceptions when reading configuration settings from files or environment variables.
//9. Data Serialization/Deserialization: Handling exceptions when converting data to/from formats like JSON, XML etc.
//10. Custom Exception Handling: Creating and handling custom exception classes for specific application scenarios.

namespace Banking_application__using_exception_handling
{
    internal class Program
    {
        public class DailyLimitExceededException : Exception
        {
            public DailyLimitExceededException(string message) : base(message)
            //calling base class constructor inside derived class constructor.
            {

            }
        }
        public class InsufficientFundsException : Exception
        {
            public InsufficientFundsException(string message) : base(message)
            {
            }
        }
        class BankAccount 
        {
            private decimal dailyLimit = 1000; 
            private decimal totalTransactionsToday = 0;
            private decimal balance = 5000;
            public void MakeTransaction(decimal amount)
            {
                if (totalTransactionsToday + amount > dailyLimit)
                {
                    
                    throw new DailyLimitExceededException("Daily transaction limit exceeded.");
                }
                if (balance < amount)
                {
                    throw new InsufficientFundsException("Insufficient funds to complete the transaction.");
                }
                totalTransactionsToday += amount;
                Console.WriteLine($"Transaction of {amount} completed successfully.");
            }
        }
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();
            // for successful transaction
            try
            {
                account.MakeTransaction(200);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Transaction attempt finished.");
            }

            Console.WriteLine("....................................................");
            //For exceeding the daily limit and insufficient funds
            try
            {
                account.MakeTransaction(800);
                account.MakeTransaction(200);
            }
            catch (DailyLimitExceededException ex)
            {
                Console.WriteLine($"Transaction Failed: {ex.Message}");
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Transaction Failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }   
    }
}
