using System.Diagnostics;
using MathGame.Models;
using static MathGame.Models.Menu;

namespace MathGame.Games
{
    internal class GameEngine
    {
        private readonly Helpers _helpers;

        public GameEngine(Helpers helpers)
        {
            _helpers = helpers;
        }
        internal decimal Play(GameType gameType, decimal score, string name, int gameNumber, Difficulty difficulty)
        {
            bool isRandom = GameType.Random == gameType;
            Console.WriteLine($"Difficulty: {difficulty.ToString()}");
            for (int i = 0; i < 5; i++)
            {
                if (isRandom)
                {
                    Random random = new Random();
                    GameType[] options =
                    {
                        GameType.Addition,
                        GameType.Substraction,
                        GameType.Multiplication,
                        GameType.Division
                    };
                    gameType = options[random.Next(options.Length)];
                }

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                NumberGenerator numberGenerator = new();
                int[] numbers = numberGenerator.GetNumbers(gameType, difficulty);
                int result = _helpers.GameResult(gameType, numbers);
                _helpers.ShowGame(gameType, numbers);
                int input = _helpers.InputValue();
                stopwatch.Stop();
                TimeSpan elapsed = stopwatch.Elapsed;

                if (result == input)
                {
                    score += _helpers.CalculateScore(elapsed);

                    Console.WriteLine($"Your answer is correct. Time: {elapsed.TotalSeconds:F2}");
                }
                else
                {
                    Console.WriteLine($"Your answer is not correct. Time: {elapsed.TotalSeconds:F2}");
                }
                Console.Write("Press any key for next question.");
                Console.ReadKey();
                Console.Clear();
            }
            _helpers.AddResultToHistory(isRandom ? GameType.Random : gameType, score, name, gameNumber, difficulty);
            Console.WriteLine($"Game over. Your score is {score}.");
            Console.ReadKey();

            return score;
        }
    }
}
