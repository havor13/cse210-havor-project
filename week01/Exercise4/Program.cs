using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        int number;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Collect user input
        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);
            }

        } while (number != 0);

        // Compute sum
        int sum = numbers.Sum();
        Console.WriteLine($"The sum is: {sum}");

        // Compute average
        double average = numbers.Average();
        Console.WriteLine($"The average is: {average}");

        // Find the largest number
        int maxNumber = numbers.Max();
        Console.WriteLine($"The largest number is: {maxNumber}");

        // Stretch challenge: Find the smallest positive number
        int smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty(0).Min();
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        // Sort and display the sorted list
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
