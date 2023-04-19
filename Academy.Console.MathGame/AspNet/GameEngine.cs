using System;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
namespace MathGame
{
    public class GameEngine
    {
        private static int correctAnswers;
        private static int incorrectAnswers;

        public enum DifficultyLevel
            {
                E,
                M,
                H
            }

public delegate bool GameDelegate(DifficultyLevel level, out double result, double rnd1 = 0, double rnd2 = 0);

/*the GameDelegate allows for the use of the operator game methods to be passed as a parameter in PlayGame
which in turn allows for the operator games parameter to be filled based on difficulty chosen*/
public static void PlayGame(GameDelegate gameDelegate)
{
    // stores difficulty levels in a dictionary with a LINQ query to allow selected operator game as GameDelegate
    //this then fills the parameters of the operator game depending on the chosen difficulty
    Random random = new Random();
    Dictionary<DifficultyLevel, Func<double>> methodMap = new Dictionary<DifficultyLevel, Func<double>>()
    {
        { DifficultyLevel.E, () => Enumerable.Range(0, int.MaxValue)
            .Select(_ => gameDelegate != null && gameDelegate(DifficultyLevel.E, out double result, random.Next(0, 11), random.Next(0, 11))
                ? result : (double?)null)
            .FirstOrDefault(r => r != null) ?? 0 },

        { DifficultyLevel.M, () => Enumerable.Range(0, int.MaxValue)
            .Select(_ => gameDelegate != null && gameDelegate(DifficultyLevel.M, out double result, random.Next(0, 26), random.Next(0, 26))
                ? result : (double?)null)
            .FirstOrDefault(r => r != null) ?? 0 },

        { DifficultyLevel.H, () => Enumerable.Range(0, int.MaxValue)
            .Select(_ => gameDelegate != null && gameDelegate(DifficultyLevel.H, out double result, random.Next(0, 101), random.Next(0, 101))
                ? result : (double?)null)
            .FirstOrDefault(r => r != null) ?? 0 },
    };

    Console.Clear();
    Console.WriteLine(@"What difficulty would you like to play at:
            E - Easy
            M - Medium
            H - Hard");
    string? diffSelected = Console.ReadLine()?.Trim().ToUpperInvariant();

    if (Enum.TryParse(diffSelected, out DifficultyLevel level))
    {
        double? resultNullable = methodMap[level].Invoke();
        double result = resultNullable.HasValue ? resultNullable.Value : 0;
        gameDelegate.Invoke(level, out result);
    }
    else
    {
        throw new ArgumentException("Invalid difficulty level.");
    }
}

        public static bool PlayAdditionGame(DifficultyLevel level, out double result, double rnd1 = 0, double rnd2 = 0)
        {
            double sum = rnd1 + rnd2;
            while (true)
            {
                Console.WriteLine($"You have gotten {correctAnswers} right and {incorrectAnswers} wrong.");
                // answer the question and check if it is correct
                Console.WriteLine($"What is {rnd1} + {rnd2}?");
                if (double.TryParse(Console.ReadLine(), out double ansChk))
                {
                    if (ansChk == sum)
                    {
                        Console.WriteLine("Congrats you got the answer right");
                        result = sum;
                        Score(true);
                        ReplayExit(PlayAdditionGame);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"Sorry you got the answer wrong, the correct answer is {sum}");
                        result = 0;
                        Score(false);
                        ReplayExit(PlayAdditionGame);
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    result = 0;
                    Score(false);
                    ReplayExit(PlayAdditionGame);
                    return false;
                }
            }
        }

        public static bool PlaySubtractionGame(DifficultyLevel level, out double result, double rnd1, double rnd2 = 0)
            {
                Console.WriteLine($"You have gotten {correctAnswers} right and {incorrectAnswers} wrong.");
                // answer the question and check if it is correct
                double diff = rnd1 - rnd2;
                while (true)
                {
                    Console.WriteLine($"What is {rnd1} - {rnd2}?");
                    if (double.TryParse(Console.ReadLine(), out double ansChk))
                    {
                        if (ansChk == diff)
                        {
                            Console.WriteLine("Congrats you got the answer right");
                            result = diff;
                            Score(true);
                            ReplayExit(PlaySubtractionGame);
                            return true;
                        }
                        else
                        {
                            Console.WriteLine($"Sorry you got the answer wrong, the correct answer is {diff}");
                            result = 0;
                            Score(false);
                            ReplayExit(PlaySubtractionGame);
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                        result = 0;
                        Score(false);
                        ReplayExit(PlaySubtractionGame);
                        return false;
                    }
                }
            }

        public static bool PlayMultiplicationGame(DifficultyLevel level, out double result, double rnd1 = 0, double rnd2 = 0)
            {
                Console.WriteLine($"You have gotten {correctAnswers} right and {incorrectAnswers} wrong.");
                double product = rnd1 * rnd2;
                while (true)
                {
                    // answer the question and check if it is correct
                    Console.WriteLine($"What is {rnd1} * {rnd2}?");
                    if (double.TryParse(Console.ReadLine(), out double ansChk))
                    {
                        if (ansChk == product)
                        {
                            Console.WriteLine("Congrats you got the answer right");
                            result = product;
                            Score(true);
                            ReplayExit(PlayMultiplicationGame);
                            return true;
                        }
                        else
                        {
                            Console.WriteLine($"Sorry you got the answer wrong, the correct answer is {product}");
                            result = 0;
                            Score(false);
                            ReplayExit(PlayMultiplicationGame);
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                        result = 0;
                        Score(false);
                        ReplayExit(PlayMultiplicationGame);
                        return false;
                    }
                }
            }

        public static bool PlayDivisionGame(DifficultyLevel level, out double result, double rnd1 = 0, double rnd2 = 0)
            {
                Console.WriteLine($"You have gotten {correctAnswers} right and {incorrectAnswers} wrong.");
                // answer the question and check if it is correct
                double quotient = Math.Round(rnd1 / (double)rnd2, 2);
                while (true)
                {
                    Console.WriteLine($"What is {rnd1} / {rnd2}? (To two decimal places)");
                    if (double.TryParse(Console.ReadLine(), out double ansChk))
                    {
                        if (ansChk == quotient)
                        {
                            Console.WriteLine("Congrats you got the answer right");
                            result = quotient;
                            Score(true);
                            ReplayExit(PlayDivisionGame);
                            return true;
                        }
                        else
                        {
                            Console.WriteLine($"Sorry you got the answer wrong, the correct answer is {quotient}");
                            result = 0;
                            Score(false);
                            ReplayExit(PlayDivisionGame);
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                        result = 0;
                        Score(false);
                        ReplayExit(PlayDivisionGame);
                        return false;
                    }
                }
            }

        public static void Score(bool isCorrect)
            {
                if (isCorrect)
                {
                    correctAnswers++;
                }
                else
                {
                    incorrectAnswers++;
                }
            }

//allows for the ReplayExit method to repeat the current running operator game
        public static async Task ReplayExit(GameDelegate gameDelegate)
        {
            // repeat the game or exit
            Console.WriteLine("Would you like to try again? (Y/N)");
            string? response = Console.ReadLine();
            if (response?.Trim().ToLower() == "y")
            {
                await PlayGame(gameDelegate);
            }
            else if (response?.Trim().ToLower() == "n")
            {
                Console.WriteLine("Back to the Main Menu!");
                await GameMenu.Menu();
            }
            else
            {
                Console.WriteLine("Invalid input, please try again");
                await ReplayExit(gameDelegate);
            }
        }
    }
}


