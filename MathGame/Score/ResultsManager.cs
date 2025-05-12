using MathGame.Menu;
using MathGame.Models;

namespace MathGame.Score
{
    internal class ResultsManager
    {
        private readonly Helpers _helpers;
        private readonly GameMenu _gameMenu;
        private List<Result> _results;

        public ResultsManager(Helpers helpers, GameMenu gameMenu)
        {
            _helpers = helpers;
            _gameMenu = gameMenu;
            _results = new List<Result>();
        }

        public void Add(Result result, string path)
        {
            _results.Add(result);
            AddToFile(result, path);
        }

        public void View()
        {
            _helpers.Options();
            GameType gameType = _gameMenu.Select();
            _results.Sort();

            Console.WriteLine("{0,-15} | {1,-15} | {2,-5}", "Name", "Game Type", "Score");
            Console.WriteLine(new string('-', 42));
            foreach (Result result in _results.Where(result => result.Game.GameType.Equals(gameType)))
            {
                Console.WriteLine("{0,-15} | {1,-15} | {2,-5}", result.User.Name, result.Game.GameType, result.Game.Score);
            }
        }

        private void AddToFile(Result result, string path)
        {
            File.AppendAllText(path, result + Environment.NewLine);
        }
    }

}