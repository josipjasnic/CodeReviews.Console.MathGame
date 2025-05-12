using MathGame.Models;
using MathGame.Score;

namespace MathGame.Games
{
    internal class Helpers
    {
        private readonly User _user;
        private readonly UserManager _userManager;
        private readonly ResultsManager _resultsManager;
        private readonly GameManager _gameManager;

        public Helpers(User user, UserManager userManager, ResultsManager resultsManager, GameManager gameManager)
        {
            _user = user;
            _userManager = userManager;
            _resultsManager = resultsManager;
            _gameManager = gameManager;
        }
        internal char OperationSymbol(GameType gameType)
        {
            return gameType switch
            {
                GameType.Addition => '+',
                GameType.Substraction => '-',
                GameType.Multiplication => '*',
                GameType.Division => '/',
                _ => throw new NotImplementedException(),
            };
        }

        internal int GameResult(GameType gameType, int[] numbers)
        {
            int firstNumber = numbers[0];
            int secondNumber = numbers[1];

            int result = gameType switch
            {
                GameType.Addition => firstNumber + secondNumber,
                GameType.Substraction => firstNumber - secondNumber,
                GameType.Multiplication => firstNumber * secondNumber,
                GameType.Division => firstNumber / secondNumber,
                _ => throw new NotImplementedException(),
            };

            return result;
        }

        internal int InputValue()
        {
            string inputValue = Console.ReadLine() ?? string.Empty;
            int input = 0;
            while (!int.TryParse(inputValue, out input))
            {
                Console.Write("Answer must be integer: ");
                inputValue = Console.ReadLine() ?? string.Empty;
            }
            return input;
        }

        internal void ShowGame(GameType gameType, int[] numbers)
        {
            var symbol = OperationSymbol(gameType);
            Console.Write($"{numbers[0]} {symbol} {numbers[1]} = ");
        }

        internal void AddResultToHistory(GameType gameType, int score, string name, int gameNumber)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "text.txt"); _user.Name = name;

            Game game = new Game(gameNumber, score, gameType);
            Result result = new Result(_user, game);

            _resultsManager.Add(result, filePath);
            _gameManager.Add(game);
            _userManager.Add(_user);
        }
    }
}
