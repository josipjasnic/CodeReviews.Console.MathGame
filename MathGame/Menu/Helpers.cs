using MathGame.Models;

namespace MathGame.Menu
{
    internal static class Helpers
    {
        internal static void ValidateNameInput(string input)
        {
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Please enter your name: ");
                input = Convert.ToString(Console.ReadKey()) ?? string.Empty;
            }
        }

        internal static GameType ValidateGameSelection(string input)
        {
            char[] validChoices = { 'a', 's', 'm', 'd', 'v', 'q' };
            while (!string.IsNullOrEmpty(input) && !validChoices.Contains(Convert.ToChar(input.ToLower())))
            {
                Console.WriteLine("Please select valid option from menu: ");
                input = Convert.ToString(Console.ReadKey()) ?? string.Empty;
            }

            return input.ToLower() switch
            {
                "a" => GameType.Addition,
                "s" => GameType.Substraction,
                "m" => GameType.Multiplication,
                "d" => GameType.Division,
                "q" => GameType.Quit,
                "v" => GameType.ViewResults,
                _ => throw new ArgumentException("Unsupported game type")
            };
        }
    }
}
