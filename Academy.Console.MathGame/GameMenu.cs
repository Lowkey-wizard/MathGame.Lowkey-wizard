using Academy.Console.MathGame.Models;
namespace MathGame
{
    internal class GameMenu : GameEngine
    {
        private static string? name; // private variable to store name so that user is not prompted again
        
        public static string GetName(string? name = "")
        {
            //makes sure that user input is not null or white spaces, will prompt again until filled
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Please enter your name:");
                name = Console.ReadLine();
                return GetName(name);
            }
            else
            {
                return name;
            }
        }

        internal static void Menu()
        {
            Console.Clear();
            if (name == null) name = GetName();
            Console.WriteLine("_________________________________");
            Console.WriteLine($"Hello {name}, today is {DateTime.Now:d}. Would you like to Play a math game?");
            Console.WriteLine($"Your current score is Right:{Game.CorrectAnswers} Wrong:{Game.IncorrectAnswers}.");
            Console.WriteLine(@"What game would you like to select below: 
                A - Addition
                S - Subtraction
                M - Multiplication
                D - Division
                Q - Quit the game");
            Console.WriteLine("_________________________________");

            string? gameSelected = Console.ReadLine()?.Trim().ToLowerInvariant();
            switch (gameSelected)
            {
                case "a":
                    PlayGame(PlayAdditionGame);
                    break;
                case "s":
                    PlayGame(PlaySubtractionGame);
                    break;
                case "m":
                    PlayGame(PlayMultiplicationGame);
                    break;
                case "d":
                    PlayGame(PlayDivisionGame);
                    break;
                case "q":
                    Console.WriteLine("Goodbye!");
                    Console.WriteLine($"Your final score is Right:{Game.CorrectAnswers} Wrong:{Game.IncorrectAnswers}.");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    Menu();
                    break;
            }
        }
    }
}