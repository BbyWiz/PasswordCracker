using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using System.Text; //text encoding 
using Step1MainProgram;
using Step2Hasher;
namespace Step3BruteForceCracker;

public class MD5BruteForceCracker
{
    public void Cracking()
    {
        // Array of target MD5 hashes we want to crack
        string[] targetHashes = new string[] { "7a95bf926a0333f57705aeac07a362a2", "08054846bbc9933fd0395f8be516a9f9" };
        //  All possible characters that can be included in the password
        string charset = "abcdefghijklmnopqrstuvwxyz";
        //  Maximum length of passwords to test
        int maxLength = 4;


        //  Begin generating all possible permutations of characters up to the max length, and check each against the target hash
        GeneratePermutations(charset, "", maxLength, targetHashes);




    }

    static void GeneratePermutations(string chars, string current, int maxLength, string[] targetHashes)
    {
        if (current.Length == maxLength)
        {
            // Check if the current permutation's MD5 hash matches any of the target hashes
            //CheckHash(current, targetHashes);
            return;
        }
        //  Recursively build each possible permutation by adding each character from the charset
        foreach (char c in chars)
        {
            string next = current + c; //append each character to each permutation
            GeneratePermutations(chars, next, maxLength, targetHashes); //  Recurse with new permutation
        }
    }
    //  Method to hash a candidate a password and check against target hashes 
    static void CheckHash(string candidate, string[] targetHashes)
    {
        using (MD5Hasher hasher = new MD5Hasher())
        {
            string hash = hasher.Hashing(candidate);

            // Check the resulting hash against each of the target hashes
            foreach (string targetHash in targetHashes)
            {
                if (hash.Equals(targetHash, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Password found! {candidate} => {hash}");
                    break;
                }
            }
        }
        // MD5Hasher instance is automatically disposed of here due to 'using' statement
    }

}
