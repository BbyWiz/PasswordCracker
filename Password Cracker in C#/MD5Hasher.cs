using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using System.Text; //text encoding 
using Step1MainProgram;
namespace Step2Hasher;

public class MD5Hasher : IDisposable
{
    private MD5 md5Hash;
    public void HashGenerator()
    {
        // Initialize the MD5 object
        this.md5Hash = MD5.Create();
    }
    public string Hashing(string source)
    {
        using (MD5 md5Hash = MD5.Create()) //  using statement for disposition of the variable from memory. Helps avoid memory leaks. Similar to using HttpClient
        {
            byte[] data = this.md5Hash.ComputeHash(Encoding.UTF8.GetBytes(source));  //  convert the input string into a byte array and compute the hash

            StringBuilder sbBuilder = new();    //  the stringbuilder collects the bytes and creates a string

            for (int i = 0; i < data.Length; i++) //  loop through each byte in the array and format them into a hexadecimal string
            {
                //  Convert each byte into a hexadecimal string and append it to the sbBuilder
                sbBuilder.Append(data[i].ToString("x2"));
            }
            //Output the hexadecimal results
            //the x2 is a 'format specifier' that converts a byte into a lowercase hex string of 2 chars each
            Console.WriteLine($"The MD5 hash of \"{source}\" is: {sbBuilder.ToString()}");
        }
        Console.WriteLine();
        return new string("Succesfully hashed");
    }
    public void Dispose()
    {
        // Dispose the MD5 object
        if (this.md5Hash != null)
        {
            this.md5Hash.Dispose();
            this.md5Hash = null;
        }


    }
}
