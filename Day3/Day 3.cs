using System.Text.RegularExpressions;

namespace Advent_Of_Code_2024.Day3;

public class Day3
{
    public static void Part1()
    {
        string input = File.ReadAllText("./Day3/input.txt");
        string pattern = @"mul\(\d{1,100},\d{1,100}\)";
        RegexOptions options = RegexOptions.Multiline;
        
        int value = 0;
        
        foreach (Match m in Regex.Matches(input, pattern, options))
        {
            string match = m.Value.Replace("mul(", "").Replace(")", "");
            Console.WriteLine("'{0}' found at index {1}.", match, m.Index);
            int[] numbers = match.Split(',').Select(int.Parse).ToArray();
            value += (numbers[0] * numbers[1]);
        }
        Console.WriteLine(value);
    }
    
    public static void Part2()
    {
        string input = File.ReadAllText("./Day3/input.txt");
        RegexOptions options = RegexOptions.Multiline;
        
        string pattern1 = @"mul\(\d{1,100},\d{1,100}\)";
        MatchCollection mulMatches = Regex.Matches(input, pattern1, options);
        
        string pattern2 = @"don't\(\)";
        MatchCollection donMatches = Regex.Matches(input, pattern2, options);
        
        string pattern3 = @"do\(\)";
        MatchCollection doMatches = Regex.Matches(input, pattern3, options);
        
        int value = 0;
        
        Dictionary<int, string?> action = new();
        List<int> actionIndexes = new();
        
        foreach (Match m in doMatches)
        {
            action.Add(m.Index, m.Value);
            actionIndexes.Add(m.Index);
        }

        foreach (Match m in donMatches)
        {
            action.Add(m.Index, m.Value);
            actionIndexes.Add(m.Index);
        }

        string? currentAction = "do()";
        foreach (Match m in mulMatches)
        {
            int nearestLessThan = actionIndexes.Where(n => n < m.Index).OrderByDescending(n => n).FirstOrDefault();
            action.TryGetValue(nearestLessThan, out currentAction);

            if (currentAction == "don't()")
            {
                continue;
            }
            
            string match = m.Value.Replace("mul(", "").Replace(")", "");
            Console.WriteLine("'{0}' found at index {1}.", match, m.Index);
            int[] numbers = match.Split(',').Select(int.Parse).ToArray();
            value += numbers[0] * numbers[1];
        }
        Console.WriteLine(value);
    }
}