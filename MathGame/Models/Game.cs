using static MathGame.Models.Menu;

namespace MathGame.Models
{
    internal class Game
    {
        public int Id { get; set; }
        public decimal Score { get; set; }
        public GameType GameType { get; set; }
        public Difficulty Difficulty { get; set; }

        public Game(int id, decimal score, GameType gameType, Difficulty difficulty)
        {
            Id = id;
            Score = score;
            GameType = gameType;
            Difficulty = difficulty;
        }
    }


    internal enum GameType
    {
        Addition,
        Substraction,
        Multiplication,
        Division,
    }
}
