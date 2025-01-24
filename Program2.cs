using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Program 1: Print Numbers in a Range
        Console.WriteLine("─── Program 1: Print Numbers in Range ───");
        int num1;
        do
        {
            Console.Write("Enter a positive integer: ");
        } while (!int.TryParse(Console.ReadLine(), out num1) || num1 <= 0);
        Console.WriteLine($"Output: {string.Join(", ", Enumerable.Range(1, num1))}\n");

        // Program 2: Multiplication Table
        Console.WriteLine("─── Program 2: Multiplication Table ───");
        Console.Write("Enter an integer: ");
        int num2 = int.Parse(Console.ReadLine());
        Console.WriteLine($"Output: {string.Join(", ", Enumerable.Range(1, 12).Select(x => x * num2))}\n");

        // Program 3: List Even Numbers
        Console.WriteLine("─── Program 3: List Even Numbers ───");
        int num3;
        do
        {
            Console.Write("Enter a positive integer: ");
        } while (!int.TryParse(Console.ReadLine(), out num3) || num3 <= 0);
        Console.WriteLine($"Output: {string.Join(", ", Enumerable.Range(1, num3).Where(x => x % 2 == 0))}\n");

        // Program 4: Compute Exponentiation
        Console.WriteLine("─── Program 4: Exponentiation ───");
        Console.Write("Enter base: ");
        int baseNum = int.Parse(Console.ReadLine());
        Console.Write("Enter exponent: ");
        int exp = int.Parse(Console.ReadLine());
        long result = 1;
        for (int i = 0; i < exp; i++) result *= baseNum;
        Console.WriteLine($"Output: {result}\n");

        // Program 5: Reverse String
        Console.WriteLine("─── Program 5: Reverse String ───");
        Console.Write("Enter text: ");
        string input5 = Console.ReadLine();
        Console.WriteLine($"Output: {new string(input5.Reverse().ToArray())}\n");

        // Program 6: Reverse Integer
        Console.WriteLine("─── Program 6: Reverse Integer ───");
        Console.Write("Enter integer: ");
        int num6 = int.Parse(Console.ReadLine());
        int reversed = int.Parse(string.Concat(Math.Abs(num6).ToString().Reverse())) * Math.Sign(num6);
        Console.WriteLine($"Output: {reversed}\n");

        // Program 7: Longest Distance Between Matching Elements
        Console.WriteLine("─── Program 7: Longest Distance ───");
        Console.Write("Enter space-separated numbers: ");
        int[] nums7 = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var dict = new Dictionary<int, (int first, int last)>();
        for (int i = 0; i < nums7.Length; i++)
        {
            if (dict.ContainsKey(nums7[i])) dict[nums7[i]] = (dict[nums7[i]].first, i);
            else dict[nums7[i]] = (i, i);
        }
        int maxDistance = dict.Max(kvp => kvp.Value.last - kvp.Value.first);
        Console.WriteLine($"Output: {maxDistance}\n");

        // Program 8: Reverse Words in Sentence
        Console.WriteLine("─── Program 8: Reverse Words ───");
        Console.Write("Enter sentence: ");
        string sentence = Console.ReadLine();
        Console.WriteLine($"Output: {string.Join(" ", sentence.Split().Reverse())}");
    }
}