using System;

class InteractiveMoneyComparisonApp
{
    static void Main()
    {
        // Boolean comparison using while statement for money
        Console.WriteLine("Boolean comparison using while statement for money:");

        Console.Write("Enter initial balance: $");
        decimal balanceWhile = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Enter withdrawal amount: $");
        decimal withdrawalWhile = Convert.ToDecimal(Console.ReadLine());

        while (balanceWhile >= withdrawalWhile && withdrawalWhile != 0)
        {
            Console.WriteLine($"Withdrawal of ${withdrawalWhile} processed. Remaining balance: ${balanceWhile}");
            Console.Write("Enter withdrawal amount (0 to exit): $");
            withdrawalWhile = Convert.ToDecimal(Console.ReadLine());
            balanceWhile -= withdrawalWhile;
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();

        Console.WriteLine();

        // Boolean comparison using do-while statement for money
        Console.WriteLine("Boolean comparison using do-while statement for money:");

        Console.Write("Enter initial balance: $");
        decimal balanceDoWhile = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Enter withdrawal amount: $");
        decimal withdrawalDoWhile = Convert.ToDecimal(Console.ReadLine());

        do
        {
            Console.WriteLine($"Withdrawal of ${withdrawalDoWhile} processed. Remaining balance: ${balanceDoWhile}");
            Console.Write("Enter withdrawal amount (0 to exit): $");
            withdrawalDoWhile = Convert.ToDecimal(Console.ReadLine());
            balanceDoWhile -= withdrawalDoWhile;
        } while (balanceDoWhile >= withdrawalDoWhile && withdrawalDoWhile != 0);

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
