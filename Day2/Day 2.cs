namespace Advent_Of_Code_2024.Day2;

public class Day2
{
    public static void Part1()
    {
        List<string> input = new(File.ReadLines("./Day2/input.txt"));

        int safeReports = 0;
        
        foreach (string line in input)
        {
            List<int> numbers = line.Split(' ').Select(int.Parse).ToList();

            bool isSafe = true;
            bool isIncreasing = true;
            
            if(numbers[0] > numbers[1])
                isIncreasing = false;
            else if(numbers[0] < numbers[1])
                isIncreasing = true;
            
            for (int i = 0; i < (numbers.Count - 1); i++)
            {
                int diff = numbers[i] - numbers[i + 1];
                int absDiff = Math.Abs(diff);
                
                if (diff <= 0 && !isIncreasing)
                    isSafe = false;
                else if (diff >= 0 && isIncreasing)
                    isSafe = false;

                
                if (absDiff >= 1 && absDiff <= 3) continue;
                isSafe = false;
            }
            
            if (isSafe)
                safeReports++;
        }
        Console.WriteLine(safeReports.ToString());
    }
    
    public static void Part2()
    {
        List<string> input = new(File.ReadLines("./Day2/input.txt"));

        int safeReports = 0;
        
        foreach (string line in input)
        {
            List<int> numbersBase = line.Split(' ').Select(int.Parse).ToList();

            for (int j = 0; j < numbersBase.Count; j++)
            {
                List<int> numbers = line.Split(' ').Select(int.Parse).ToList();
                
                numbers.RemoveAt(j);
                
                bool isSafe = true;
                bool isIncreasing = true;
            
                if(numbers[0] > numbers[1])
                    isIncreasing = false;
                else if(numbers[0] < numbers[1])
                    isIncreasing = true;
            
            
            
                for (int i = 0; i < (numbers.Count - 1); i++)
                {
                    int diff = numbers[i] - numbers[i + 1];
                    int absDiff = Math.Abs(diff);
                
                    if (diff <= 0 && !isIncreasing)
                        isSafe = false;
                    else if (diff >= 0 && isIncreasing)
                        isSafe = false;

                
                    if (absDiff >= 1 && absDiff <= 3) continue;
                    isSafe = false;
                }
            
                if (isSafe){
                    safeReports++;
                    break;
                }
            }
        }
        Console.WriteLine(safeReports.ToString());
    }
}