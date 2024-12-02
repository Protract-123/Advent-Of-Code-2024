namespace Advent_Of_Code_2024.Day1;

public class Day1
{
    public static void Part1()
    {
        List<string> input = new(File.ReadLines("./Day1/input.txt"));

        List<int> leftSide = new();
        List<int> rightSide = new();
        
        foreach (string line in input)
        {
            string[] splitLine = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            leftSide.Add(int.Parse(splitLine[0]));
            rightSide.Add(int.Parse(splitLine[1]));
        }
        
        leftSide.Sort();
        rightSide.Sort();
        
        long sum = 0;

        for (int i = 0; i < leftSide.Count; i++)
        {
            sum += Math.Abs(rightSide[i] - leftSide[i]);
        }
        
        Console.WriteLine(sum.ToString());
    }

    public static void Part2()
    {
        List<string> input = new(File.ReadLines("./Day1/input.txt"));

        List<int> leftSide = new();
        List<int> rightSide = new();
        
        foreach (string line in input)
        {
            string[] splitLine = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            leftSide.Add(int.Parse(splitLine[0]));
            rightSide.Add(int.Parse(splitLine[1]));
        }

        Dictionary<int, int> timesSeen = new();

        foreach (int number in rightSide)
        {
            
            if (timesSeen.TryGetValue(number, out int value))
                timesSeen[number] = ++value;
            else timesSeen.Add(number, 1);
        }

        long similarity = 0;

        foreach (int number in leftSide)
        {
            timesSeen.TryGetValue(number, out int value);
            similarity += number * value;
        }
        
        Console.WriteLine(similarity.ToString());
    }
}