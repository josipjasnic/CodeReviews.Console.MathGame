using static MathGame.Models.Menu;

namespace MathGame.Menu
{
    internal class StartMenu
    {
        internal void GreetingMessage()
        {
            Console.WriteLine("Hello, Welcome to the Math Game!");
        }

        internal string GetPlayerName()
        {
            Console.Write("Please enter your name: ");

            string name = Console.ReadLine() ?? string.Empty;
            Helpers.ValidateNameInput(name);
            Console.Clear();
            return name;
        }

        private void Options()
        {
            Console.WriteLine("N- New game");
            Console.WriteLine("O - Options");
            Console.WriteLine("H - High scores");
            Console.WriteLine("Q - Quit");
            Console.Write("Select the option: ");
        }

        internal MenuOptions Select()
        {
            Options();
            ConsoleKeyInfo selectedOption = Console.ReadKey();
            MenuOptions option = Helpers.ValidateSelection(selectedOption);
            Console.Clear();
            return option;
        }
    }
}
