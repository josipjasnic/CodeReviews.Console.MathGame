using MathGame.Models;
using static MathGame.Models.Menu;

namespace MathGame.Games
{
    internal class NumberGenerator
    {
        private Random _random;

        public NumberGenerator()
        {
            _random = new Random();
        }

        internal int[] GetNumbers(GameType gameType, Difficulty difficulty)
        {
            int upperLimit = difficulty switch
            {
                Difficulty.Easy => 11,
                Difficulty.Medium => 51,
                Difficulty.Hard => 101,
                _ => 11
            };
            int firstNumber = _random.Next(upperLimit);
            int secondNumber = _random.Next(upperLimit);

            if (gameType.Equals(GameType.Division))
            {
                if (firstNumber < secondNumber)
                {
                    int temp = firstNumber;
                    firstNumber = secondNumber;
                    secondNumber = temp;
                }

                while (secondNumber == 0)
                    secondNumber = _random.Next(firstNumber);

                while (firstNumber % secondNumber != 0)
                {
                    secondNumber = _random.Next(firstNumber);
                }
            }

            return [firstNumber, secondNumber];
        }
    }
}
