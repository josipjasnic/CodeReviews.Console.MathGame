namespace MathGame.Models
{
    internal class Game
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public GameType GameType { get; set; }

        public Game(int id, int score, GameType gameType)
        {
            Id = id;
            Score = score;
            GameType = gameType;
        }
    }


    internal enum GameType
    {
        Addition,
        Substraction,
        Multiplication,
        Division,
        Quit,
        ViewResults
    }
}
