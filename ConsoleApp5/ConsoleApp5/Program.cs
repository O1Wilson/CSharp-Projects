using System;
using System.Collections.Generic;

class ArrayAndListApp
{
    static void Main()
    {
        // Create a one-dimensional Array of strings
        string[] stringArray = { "Apple", "Banana", "Cherry", "Date", "Elderberry" };

        // Ask the user to select an index and display the string at that index
        Console.WriteLine("Select an index for the string array (0-4):");
        int stringIndex = Convert.ToInt32(Console.ReadLine());

        if (stringIndex >= 0 && stringIndex < stringArray.Length)
        {
            Console.WriteLine($"String at index {stringIndex}: {stringArray[stringIndex]}");
        }
        else
        {
            Console.WriteLine("Invalid index. The selected index does not exist.");
        }

        Console.WriteLine();

        // Create a one-dimensional Array of integers
        int[] intArray = { 10, 20, 30, 40, 50 };

        // Ask the user to select an index and display the integer at that index
        Console.WriteLine("Select an index for the integer array (0-4):");
        int intIndex = Convert.ToInt32(Console.ReadLine());

        if (intIndex >= 0 && intIndex < intArray.Length)
        {
            Console.WriteLine($"Integer at index {intIndex}: {intArray[intIndex]}");
        }
        else
        {
            Console.WriteLine("Invalid index. The selected index does not exist.");
        }

        Console.WriteLine();

        // Create a list of strings
        List<string> stringList = new List<string> { "Lemon", "Mango", "Orange", "Papaya", "Quince" };

        // Ask the user to select an index and display the content at that index
        Console.WriteLine("Select an index for the string list (0-4):");
        int listIndex = Convert.ToInt32(Console.ReadLine());

        if (listIndex >= 0 && listIndex < stringList.Count)
        {
            Console.WriteLine($"Content at index {listIndex}: {stringList[listIndex]}");
        }
        else
        {
            Console.WriteLine("Invalid index. The selected index does not exist.");
        }
    }
}