namespace GameMenu
{
    using GameEngine;
    internal class GameMenu
    {
        internal void Menu()
        {
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
                    GameEngine.PlayAdditionGame();
                    break;
                case "s":
                    GameEngine.PlaySubtractionGame();
                    break;
                case "m":
                    GameEngine.PlayMultiplicationGame();
                    break;
                case "d":
                    GameEngine.PlayDivisionGame();
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

            Console.ReadLine();
        }

    }
}