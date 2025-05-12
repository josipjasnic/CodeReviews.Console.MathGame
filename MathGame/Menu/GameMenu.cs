using MathGame.Models;

namespace MathGame.Menu
{
    internal class GameMenu
    {
        internal void Options(string name)
        {
            Console.WriteLine($"Hello, {name}. Available games:");
            Console.WriteLine("A - Addition game.");
            Console.WriteLine("S - Subtraction game.");
            Console.WriteLine("M - Multiplication game.");
            Console.WriteLine("D - Division game.");
            Console.WriteLine("Q - Quit.");
            Console.WriteLine("V - View previous games.");
            Console.Write("Select the game: ");

        }

        internal GameType Select()
        {
            string selectedGame = Console.ReadLine() ?? string.Empty;
            GameType gameType = Helpers.ValidateGameSelection(selectedGame);
            Console.Clear();
            return gameType;
        }
    }
}
