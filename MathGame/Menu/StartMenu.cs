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
    }
}
