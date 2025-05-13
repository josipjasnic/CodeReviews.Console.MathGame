using static MathGame.Models.Menu;

namespace MathGame.Menu
{
    internal class Options
    {

        public Difficulty Difficulty { get; set; }

        private void ValidOptions()
        {
            Console.WriteLine("Select difficulty: ");
            Console.WriteLine("E - Easy");
            Console.WriteLine("M - Medium");
            Console.WriteLine("H- Hard");
            Console.Write("Select the option: ");
        }

        internal Difficulty SelectDifficulty()
        {
            ValidOptions();
            ConsoleKeyInfo selectedOption = Console.ReadKey();
            return Helpers.ValidateDifficulty(selectedOption);
        }
    }
}
