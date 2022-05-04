// User enters list of numbers and then find the sum, average, and largest number.
// User enters list of numbers. Find the sum, average, largest and smallest numbers, and sorts the list.

using System;
using System.Linq;
using System.Collections.Generic;

List<float> numbers = new List<float>();

Console.WriteLine("Enter a list of numbers, type 0 when finished.");

float number = 10;

while (number != 0)
{
    Console.Write("Enter number: ");
    string numberStr = Console.ReadLine();
    number = float.Parse(numberStr);
    if (number != 0)
    {
        numbers.Add(number);
    }
}

float sum = numbers.Sum();
float count = numbers.Count();
float ave = numbers.Average();
float maxNum = numbers.Max();
float minNum = numbers.Min();

Console.WriteLine($"\nSum: {sum}");
Console.WriteLine($"Number of items: {count}");
Console.WriteLine($"Average: {ave}");
Console.WriteLine($"Largest number: {maxNum}");
Console.WriteLine($"Smallest number: {minNum}");

Console.WriteLine("\nList as entered");
foreach (float num in numbers)
{
    Console.WriteLine(num);
}

numbers.Sort();
Console.WriteLine("\nSorted list");
foreach (float num in numbers)
{
    Console.WriteLine(num);
}

Console.WriteLine();