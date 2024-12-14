namespace Advent_Of_Code_2024.Day4;

public class Day4
{
    public static void Part1()
    {
        List<string> input = new(File.ReadAllLines("./Day3/input.txt"));
        
        int rows = input.Count;
        int cols = input[0].Length; // Assuming all strings are of the same length

        char[,] charArray = new char[rows, cols];

        
        int rowCount = charArray.GetLength(0);
        int colCount = charArray.GetLength(1);
        int gridSize = 4;
        
        for (int startRow = 0; startRow <= rowCount - gridSize; startRow++)
        {
            for (int startCol = 0; startCol <= colCount - gridSize; startCol++)
            {
                char[,] grid = new char[gridSize, gridSize];

                for (int i = 0; i < gridSize; i++)
                {
                    for (int j = 0; j < gridSize; j++)
                    {
                        grid[i, j] = charArray[startRow + i, startCol + j];
                    }
                }

                // Process the grid
                
            }
        }    
    }

    public static void FindXmas(char[,] grid)
    {
        
    }
}