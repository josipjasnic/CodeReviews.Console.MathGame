using MathGame.Models;

namespace MathGame.Games
{
    internal class GameManager
    {
        private readonly List<Game> _games;
        public GameManager()
        {
            _games = new List<Game>();
        }

        public void Add(Game game)
        {
            _games.Add(game);
        }
    }
}
