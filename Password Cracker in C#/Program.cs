using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using System.Text;
using Step2Hasher;
using Step3BruteForceCracker; //text encoding 
namespace Step1MainProgram;

class Program
{
    static void Main(string[] args)
    {
        MD5Hasher hashMe = new();
        Console.WriteLine("What STRING are you hashing?");
        try
        {
            // Get user input and hash it
            string userInput = Console.ReadLine();
            string hashedInput = hashMe.Hashing(userInput);
            Console.WriteLine($"The MD5 hash of {userInput} is: {hashedInput}");

            // Now, let's use the brute force cracker as an example
            Console.WriteLine("\nStarting MD5 brute force cracker for demonstration...");
            MD5BruteForceCracker cracker = new MD5BruteForceCracker();
            cracker.Cracking(); // Run the brute force attack
        }
        catch (Exception Error)
        {
            Console.WriteLine($"Please type a valid string: \n {Error}");
        }
        Console.ReadLine(); // Wait for user input before closing
    }
}