using MathGame.Games;
using MathGame.Menu;
using MathGame.Models;
using MathGame.Score;
using static MathGame.Models.Menu;

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
            Options options = new();
            Difficulty difficulty = Difficulty.Easy;
            int gameNumber = 1;
            decimal score = 0;

            startMenu.GreetingMessage();
            string name = startMenu.GetPlayerName();

            MenuOptions menuOption = startMenu.Select();

            while (!menuOption.Equals(MenuOptions.Quit))
            {
                if (menuOption.Equals(MenuOptions.NewGame))
                {
                    GameType gameType = gameMenu.Select();

                    score = gameEngine.Play(gameType, score, name, gameNumber, difficulty);
                }
                else if (menuOption.Equals(MenuOptions.Options))
                {
                    difficulty = options.SelectDifficulty();
                }
                else if (menuOption.Equals(MenuOptions.Highscore))
                {
                    resultsManager.View();
                }

                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                Console.Clear();
                menuOption = startMenu.Select();
            }
        }
    }
}