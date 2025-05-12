namespace MathGame.Models
{
    internal class Result
    {
        public User User { get; set; }
        public Game Game { get; set; }
        public Result(User user, Game game)
        {
            User = user;
            Game = game;
        }
        public override string ToString()
        {
            return $"{User.Name},{Game.GameType},{Game.Score}";
        }
    }
}
