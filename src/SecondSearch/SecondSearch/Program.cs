using System;
using System.Linq;
using System.Collections.Generic;

public class MainClass
{
    public static void Main()
    {
        var n = GetNumberFromConsole();
        var firstNumbers = GetNumbersFromConsole().ToArray();
        var m = GetNumberFromConsole();
        var secondNumbers = GetNumbersFromConsole().ToArray();
        var results = new int[secondNumbers.Length];
        
        for(var i = 0; i < secondNumbers.Length; i++)
        {
            results[i] = NumberCount(firstNumbers, secondNumbers[i]);
        }
        
        Console.WriteLine(string.Join(" ", results));
    }
    
    private static int NumberCount(int[] numbers, int target)
    {
        var foundLeftIndex = LeftBinarySearch(numbers, target);
        var foundRightIndex = RightBinarySearch(numbers, target);
        if (foundLeftIndex == -1 || foundRightIndex == -1) return 0;
        return foundRightIndex + 1 - foundLeftIndex;
    }
    
    private static int RightBinarySearch(int[] numbers, int target) 
    {
        var left = 0;
        var right = numbers.Length;
        
        while(left + 1 < right)
        {
            var middle = left + (right - left) / 2;
            
            if (numbers[middle] > target) 
            {
                right = middle;
            }
            
            else
            {
                left = middle;
            }
        }
        
        if (numbers[left] == target) return left;
        
        return -1;
    }
    
    private static int LeftBinarySearch(int[] numbers, int target) 
    {
        var left = -1;
        var right = numbers.Length - 1;
        
        while(left + 1 < right)
        {
            var middle = left + (right - left) / 2;
            
            if (numbers[middle] < target) 
            {
                left = middle;
            }
            
            if (numbers[middle] >= target)
            {
                right = middle;
            }
        }
        
        if (numbers[right] == target) return right;
        
        return -1;
    }
    
    private static IEnumerable<int> GetNumbersFromConsole() => Console.ReadLine().Split().Select(int.Parse);
    
    private static int GetNumberFromConsole() => int.Parse(Console.ReadLine());
}