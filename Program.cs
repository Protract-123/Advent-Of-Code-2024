namespace Advent_Of_Code_2024;

internal class Program
{
    static void Main(string[] args)
    {
        // Dictionary mapping integers to function delegates
        var functionMap = new Dictionary<int, Action?>
        {
            { 11, Day1.Day1.Part1 },
            { 12, Day1.Day1.Part2 },
            { 21, Day2.Day2.Part1 },
            { 22, Day2.Day2.Part2 }
        };

        // Prompt the user to enter the day and part
        Console.Write("Enter the day (as an integer): ");
        string? dayInput = Console.ReadLine();

        Console.Write("Enter the part (as an integer): ");
        string? partInput = Console.ReadLine();

        if (int.TryParse(dayInput, out int day) && int.TryParse(partInput, out int part))
        {
            // Combine day and part into a single key
            int combinedKey = day * 10 + part;

            if (functionMap.TryGetValue(combinedKey, out Action? function))
            {
                // Call the corresponding function
                function?.Invoke();
            }
            else
            {
                Console.WriteLine("No function found for the given day and part.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter valid integers for day and part.");
        }

        // Wait for the user to press a key before exiting
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}