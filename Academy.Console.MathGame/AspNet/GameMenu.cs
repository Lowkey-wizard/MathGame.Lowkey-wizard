using System;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
namespace MathGame
{
    public class GameMenu : GameEngine
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

        public static async Task Menu()
        {
            Console.Clear();
            if (name == null) name = GetName();
            Console.WriteLine("_________________________________");
            Console.WriteLine($"Hello {name}, today is {DateTime.Now:d}. Would you like to Play a math game?");
            Console.WriteLine(@"What game would you like to select below: 
                A - Addition
                S - Subtraction
                M - Multiplication
                D - Division
                Q - Quit the game");
            Console.WriteLine("_________________________________");

            string? gameSelected = await Task.FromResult(Console.ReadLine()?.Trim().ToLowerInvariant());
            switch (gameSelected)
            {
                case "a":
                    await PlayGame(PlayAdditionGame);
                    break;
                case "s":
                    await PlayGame(PlaySubtractionGame);
                    break;
                case "m":
                    await PlayGame(PlayMultiplicationGame);
                    break;
                case "d":
                    await PlayGame(PlayDivisionGame);
                    break;
                case "q":
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    await Menu();
                    break;
            }
        }
    }
}