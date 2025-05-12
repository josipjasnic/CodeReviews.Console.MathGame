using MathGame.Games;
using MathGame.Menu;
using MathGame.Models;
using MathGame.Score;

namespace MathGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            User user = new();
            StartMenu startMenu = new();
            GameMenu gameMenu = new();
            GameManager gameManager = new();
            UserManager userManager = new();
            Score.Helpers scoreHelpers = new();
            ResultsManager resultsManager = new(scoreHelpers, gameMenu);
            Games.Helpers gameHelpers = new(user, userManager, resultsManager, gameManager);
            GameEngine gameEngine = new(gameHelpers);

            int gameNumber = 1;
            int score = 0;

            startMenu.GreetingMessage();
            string name = startMenu.GetPlayerName();

            gameMenu.Options(name);
            GameType gameType = gameMenu.Select();

            while (!gameType.Equals(GameType.Quit))
            {
                if (gameType.Equals(GameType.ViewResults))
                {
                    resultsManager.View();

                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                    gameMenu.Options(name);
                    gameType = gameMenu.Select();
                }
                else if (gameType != GameType.Quit)
                {
                    score = gameEngine.Play(gameType, score, name, gameNumber);

                    Console.Clear();
                    gameMenu.Options(name);
                    gameType = gameMenu.Select();
                    gameNumber++;
                }
            }
        }
    }
}