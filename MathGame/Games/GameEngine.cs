using MathGame.Models;

namespace MathGame.Games
{
    internal class GameEngine
    {
        private readonly Helpers _helpers;

        public GameEngine(Helpers helpers)
        {
            _helpers = helpers;
        }
        internal int Play(GameType gameType, int score, string name, int gameNumber)
        {
            for (int i = 0; i < 5; i++)
            {
                NumberGenerator numberGenerator = new();
                int[] numbers = numberGenerator.GetNumbers(gameType);
                int result = _helpers.GameResult(gameType, numbers);
                _helpers.ShowGame(gameType, numbers);
                int input = _helpers.InputValue();

                if (result == input)
                {
                    Console.Write("Your answer is correct. ");
                    score++;
                }
                else
                {
                    Console.Write("Your answer is not correct. ");
                }
                Console.Write("Press any key for next question.");
                Console.ReadKey();
                Console.Clear();
            }
            _helpers.AddResultToHistory(gameType, score, name, gameNumber);
            Console.Write($"Game over. Your score is {score}.\nPress any key to continue.");
            Console.ReadKey();

            return score;
        }
    }
}
