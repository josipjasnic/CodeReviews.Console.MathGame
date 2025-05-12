using MathGame.Models;

namespace MathGame.Games
{
    internal class NumberGenerator
    {
        private Random _random;

        public NumberGenerator()
        {
            _random = new Random();
        }

        internal int[] GetNumbers(GameType gameType)
        {
            int firstNumber = _random.Next(100);
            int secondNumber = _random.Next(100);

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
