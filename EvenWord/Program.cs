namespace EvenWord;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");


// Problem: Write a function solution that, given a string S conssiting of N characters, return the minimun number of leteers that must be deleted to obtain an even word


public class EvenWord
{
    public int EvenWordGenerator(string word)
    {
        // write your code in C# 9.0 with .NET 5.0
        int count = 0;
        int[] alphabet = new int[26];
        for (int i = 0; i < word.Length; i++)
        {
            alphabet[word[i] - 'a']++;
        }
        for (int i = 0; i < 26; i++)
        {
            if (alphabet[i] % 2 != 0)
            {
                count++;
            }
        }
        return count;
    }
}

class Program
{
    static void Main()
    {
        EvenWord evenWord = new EvenWord();
        Console.WriteLine(evenWord.EvenWordGenerator("hiiimynameisricardo"));
    }
}