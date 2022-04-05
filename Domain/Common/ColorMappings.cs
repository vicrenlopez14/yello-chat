namespace Domain.Common;

public class ColorMappings
{
    public static Dictionary<ConsoleColor, int> ConsoleToCode = new Dictionary<ConsoleColor, int>
    {
        {ConsoleColor.Blue, 1},
        {ConsoleColor.Cyan, 2},
        {ConsoleColor.DarkBlue, 3},
        {ConsoleColor.DarkCyan, 4},
        {ConsoleColor.DarkGreen, 5},
        {ConsoleColor.DarkMagenta, 6},
        {ConsoleColor.DarkRed, 7},
        {ConsoleColor.DarkYellow, 8},
        {ConsoleColor.Green, 9},
        {ConsoleColor.Magenta, 10},
        {ConsoleColor.Red, 11},
        {ConsoleColor.White, 12},
        {ConsoleColor.Yellow, 13},
    };

    public static Dictionary<int, ConsoleColor> CodeToConsole = new Dictionary<int, ConsoleColor>
    {
        {1, ConsoleColor.Blue},
        {2, ConsoleColor.Cyan},
        {3, ConsoleColor.DarkBlue},
        {4, ConsoleColor.DarkCyan},
        {5, ConsoleColor.DarkGreen},
        {6, ConsoleColor.DarkMagenta},
        {7, ConsoleColor.DarkRed},
        {8, ConsoleColor.DarkYellow},
        {9, ConsoleColor.Green},
        {10, ConsoleColor.Magenta},
        {11, ConsoleColor.Red},
        {12, ConsoleColor.White},
        {13, ConsoleColor.Yellow},
    };
}