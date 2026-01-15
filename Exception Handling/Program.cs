using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception_Handling
{
    //Exception handling in c#
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter a number: ");
                int num1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter another number: ");
                int num2 = Convert.ToInt32(Console.ReadLine());
                int result = num1 / num2;
                Console.WriteLine("Result: " + result);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Error: Cannot divide by zero. " + ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: Invalid input format. " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Execution completed.");
            }
        }
    }
}
