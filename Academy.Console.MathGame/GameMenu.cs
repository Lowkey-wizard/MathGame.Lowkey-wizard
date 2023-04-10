namespace MathGame
{
    public partial class GameMenu
    {
        public static void Menu()
        {
            Console.WriteLine("Please enter your name:");
            string? name = Console.ReadLine();
            Console.WriteLine("_________________________________");
            Console.WriteLine($"Hello {name}, today is {DateTime.Now:d}. Would you like to Play a math game?");
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
                    MathGame.GameEngine.PlayAdditionGame();
                    break;
                case "s":
                    MathGame.GameEngine.PlaySubtractionGame();
                    break;
                case "m":
                    MathGame.GameEngine.PlayMultiplicationGame();
                    break;
                case "d":
                    MathGame.GameEngine.PlayDivisionGame();
                    break;
                case "q":
                    Console.WriteLine("Goodbye!");
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