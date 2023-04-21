using Academy.Console.MathGame.Models;
namespace MathGame
{
    internal class GameEngine
    {

        public enum DifficultyLevel
        {
            E,
            M,
            H
        }

        internal delegate bool GameDelegate(DifficultyLevel level, out double result, double rnd1 = 0, double rnd2 = 0);

        /*the GameDelegate allows for the use of the operator game methods to be passed as a parameter in PlayGame
        which in turn allows for the operator games parameter to be filled based on difficulty chosen*/
        internal static void PlayGame(GameDelegate gameDelegate)
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

        internal static bool PlayAdditionGame(DifficultyLevel level, out double result, double rnd1 = 0, double rnd2 = 0)
        {
            double sum = rnd1 + rnd2;
            while (true)
            {
                // answer the question and check if it is correct
                Console.WriteLine($"What is {rnd1} + {rnd2}?");
                if (double.TryParse(Console.ReadLine(), out double ansChk))
                {
                    if (ansChk == sum)
                    {
                        Console.WriteLine("Congrats you got the answer right");
                        result = sum;
                        Game.Score(true);
                        ReplayExit(PlayAdditionGame);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"Sorry you got the answer wrong, the correct answer is {sum}");
                        result = 0;
                        Game.Score(false);
                        ReplayExit(PlayAdditionGame);
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    result = 0;
                    Game.Score(false);
                    ReplayExit(PlayAdditionGame);
                    return false;
                }
            }
        }

        internal static bool PlaySubtractionGame(DifficultyLevel level, out double result, double rnd1, double rnd2 = 0)
        {
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
                        Game.Score(true);
                        ReplayExit(PlaySubtractionGame);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"Sorry you got the answer wrong, the correct answer is {diff}");
                        result = 0;
                        Game.Score(false);
                        ReplayExit(PlaySubtractionGame);
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    result = 0;
                    Game.Score(false);
                    ReplayExit(PlaySubtractionGame);
                    return false;
                }
            }
        }

        internal static bool PlayMultiplicationGame(DifficultyLevel level, out double result, double rnd1 = 0, double rnd2 = 0)
        {
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
                        Game.Score(true);
                        ReplayExit(PlayMultiplicationGame);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"Sorry you got the answer wrong, the correct answer is {product}");
                        result = 0;
                        Game.Score(false);
                        ReplayExit(PlayMultiplicationGame);
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    result = 0;
                    Game.Score(false);
                    ReplayExit(PlayMultiplicationGame);
                    return false;
                }
            }
        }

        internal static bool PlayDivisionGame(DifficultyLevel level, out double result, double rnd1 = 0, double rnd2 = 0)
        {
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
                        Game.Score(true);
                        ReplayExit(PlayDivisionGame);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"Sorry you got the answer wrong, the correct answer is {quotient}");
                        result = 0;
                        Game.Score(false);
                        ReplayExit(PlayDivisionGame);
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    result = 0;
                    Game.Score(false);
                    ReplayExit(PlayDivisionGame);
                    return false;
                }
            }
        }

        //allows for the ReplayExit method to repeat the current running operator game
        internal static void ReplayExit(GameDelegate gameDelegate)
        {
            // repeat the game or exit
            Console.WriteLine("Would you like to try again? (Y/N)");
            string? response = Console.ReadLine();
            if (response?.Trim().ToLower() == "y")
            {
                PlayGame(gameDelegate);
            }
            else if (response?.Trim().ToLower() == "n")
            {
                Console.WriteLine("Back to the Main Menu!");
                GameMenu.Menu();
            }
            {
                Console.WriteLine("Invalid input, please try again");
                ReplayExit(gameDelegate);
            }
        }
    }
}