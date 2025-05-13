using MathGame.Models;
using static MathGame.Models.Menu;

namespace MathGame.Menu
{
    internal static class Helpers
    {
        internal static void ValidateNameInput(string input)
        {
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Please enter your name: ");
                input = Console.ReadLine() ?? string.Empty;
            }
        }

        internal static GameType ValidateGameSelection(ConsoleKeyInfo input)
        {
            char[] validChoices = ['a', 's', 'm', 'd', 'r'];

            while (!validChoices.Contains(char.ToLower(input.KeyChar)))
            {
                Console.WriteLine("Please select valid option from menu: ");
                input = Console.ReadKey();
            }

            return input.Key.ToString().ToLower() switch
            {
                "a" => GameType.Addition,
                "s" => GameType.Substraction,
                "m" => GameType.Multiplication,
                "d" => GameType.Division,
                "r" => GameType.Random,
                _ => throw new ArgumentException("Unsupported game type")
            };
        }

        internal static MenuOptions ValidateSelection(ConsoleKeyInfo input)
        {
            char[] validChoices = ['n', 'o', 'h', 'q'];

            while (!validChoices.Contains(char.ToLower(input.KeyChar)))
            {
                Console.WriteLine("Please select valid option from menu: ");
                input = Console.ReadKey();
            }

            return input.Key.ToString().ToLower() switch
            {
                "n" => MenuOptions.NewGame,
                "o" => MenuOptions.Options,
                "h" => MenuOptions.Highscore,
                "q" => MenuOptions.Quit,
                _ => throw new ArgumentException("Unsupported option")
            };
        }

        internal static Difficulty ValidateDifficulty(ConsoleKeyInfo input)
        {
            char[] validChoices = ['e', 'm', 'h'];

            while (!validChoices.Contains(char.ToLower(input.KeyChar)))
            {
                Console.WriteLine("Please select valid option from menu: ");
                input = Console.ReadKey(intercept: true);
            }

            return input.Key.ToString().ToLower() switch
            {
                "e" => Difficulty.Easy,
                "m" => Difficulty.Medium,
                "h" => Difficulty.Hard,
                _ => throw new ArgumentException("Unsupported option")
            };
        }
    }
}
