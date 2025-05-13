using MathGame.Models;

namespace MathGame.Menu
{
    internal class GameMenu
    {
        private void Options()
        {
            Console.WriteLine("A - Addition game.");
            Console.WriteLine("S - Subtraction game.");
            Console.WriteLine("M - Multiplication game.");
            Console.WriteLine("D - Division game.");
            Console.WriteLine("R - Random game.");
            Console.Write("Select the game: ");
        }

        internal GameType Select()
        {
            Options();
            ConsoleKeyInfo selectedGame = Console.ReadKey();
            GameType gameType = Helpers.ValidateGameSelection(selectedGame);
            Console.Clear();
            return gameType;
        }
    }
}
