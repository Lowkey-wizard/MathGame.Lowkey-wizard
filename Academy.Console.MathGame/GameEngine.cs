namespace GameEngine
{
    using GameMenu;
    internal class GameEngine
    {
            Random random = new Random();

        internal void EasyDiff()
            {
                if (PlayDivisionGame())
                {
                    int dividend = random.Next(26);
                    int divisor = random.Next(1, 11);
                }
                else if (PlayMultiplicationGame())
                {
                    int factor1, factor2 = random.Next(11);
                }
                else
                {
                    double rnd1, rnd2 = random.Next(51);
                }

            }

            internal void MedDiff()
            {
                if (PlayDivisionGame())
                {
                    int dividend = random.Next(51);
                    int divisor = random.Next(1, 25);
                }
                else if (PlayMultiplicationGame())
                {
                    int factor1, factor2 = random.Next(51);
                }
                else
                {
                    double rnd1, rnd2 = random.Next(101);
                }

            }

            internal void HardDiff()
            {
                if (PlayDivisionGame())
                {
                    int dividend = random.Next(101);
                    int divisor = random.Next(1, 51);
                }
                else if (PlayMultiplicationGame())
                {
                    int factor1, factor2 = random.Next(101);
                }
                else
                {
                    double rnd1, rnd2 = random.Next(251);
                }

            }

            internal void ReplayExit()
            {
                // repeat the game or exit
                Console.WriteLine("Would you like to try again? (Y/N)");
                string? response = Console.ReadLine();
                if (response?.Trim().ToLower() == "y")
                {
                    // choose current method in use in Program.cs
                }
                else
                {
                    Console.WriteLine("Goodbye!");
                    GameMenu.Menu();
                }
            }
        internal void PlayAdditionGame()
        {
            while (true)
            {
                // generating two random numbers and their sum
                Random random = new Random();
                int rnd1 = random.Next(201);
                int rnd2 = random.Next(201);
                int sum = rnd1 + rnd2;

                // answering the question and check if it is correct
                Console.WriteLine($"What is {rnd1} + {rnd2}?");
                if (int.TryParse(Console.ReadLine(), out int ansChk))
                {
                    if (ansChk == sum)
                    {
                        Console.WriteLine("Congrats you got the answer right");
                    }
                    else
                    {
                        Console.WriteLine($"Sorry you got the answer wrong, the correct answer is {sum}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }

                // repeat the game or exit
                Console.WriteLine("Would you like to try again? (Y/N)");
                string? response = Console.ReadLine();
                if (response?.Trim().ToLower() == "y")
                {
                    PlayAdditionGame();
                }
                else
                {
                    Console.WriteLine("Goodbye!");
                    GameMenu.Menu();
                }
            }
        }

        internal void PlaySubtractionGame()
        {
            while (true)
            {
                // generating two random numbers and their difference
                Random random = new Random();
                double rnd1 = random.Next(201);
                double rnd2 = random.Next(201);
                double diff = rnd1 - rnd2;

                // answering the question and check if it is correct
                Console.WriteLine($"What is {rnd1} - {rnd2}?");
                if (double.TryParse(Console.ReadLine(), out double ansChk))
                {
                    if (ansChk == diff)
                    {
                        Console.WriteLine("Congrats you got the answer right");
                    }
                    else
                    {
                        Console.WriteLine($"Sorry you got the answer wrong, the correct answer is {diff}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }

                // repeat the game or exit
                Console.WriteLine("Would you like to try again? (Y/N)");
                string? response = Console.ReadLine();
                if (response?.Trim().ToLower() == "y")
                {
                    PlaySubtractionGame();
                }
                else
                {
                    Console.WriteLine("Goodbye!");
                    GameMenu.Menu();
                }
            }
        }

        internal void PlayMultiplicationGame()
        {
            // generating two random numbers and their product
            Random random = new Random();
            int factor1 = random.Next(11);
            int factor2 = random.Next(11);
            int product = factor1 * factor2;

            // asking the question and checking the answer
            Console.WriteLine($"What is {factor1} * {factor2}?");
            int userAnswer;
            while (!int.TryParse(Console.ReadLine(), out userAnswer))
            {
                Console.WriteLine("Invalid input, please enter an integer.");
            }
            if (userAnswer == product)
            {
                Console.WriteLine("Congrats you got the answer right");
            }
            else
            {
                Console.WriteLine($"Sorry you got the answer wrong, the correct answer is {product}");
            }

            // repeat the game or exit
            Console.WriteLine("Would you like to try again? (Y/N)");
            string? response = Console.ReadLine();
            if (response?.Trim().ToLower() == "y")
            {
                PlayMultiplicationGame();
            }
            else
            {
                Console.WriteLine("Goodbye!");
                GameMenu.Menu();
            }
        }

        internal void PlayDivisionGame()
        {
            // generating two random numbers and their quotient
            Random random = new Random();
            int dividend = random.Next(101);
            int divisor = random.Next(1, 11);
            double quotient = (double)dividend / divisor;

            // asking the question and checking the answer
            Console.WriteLine($"What is {dividend} / {divisor}? (Round to 2 decimal places)");
            double userAnswer;
            while (!double.TryParse(Console.ReadLine(), out userAnswer))
            {
                Console.WriteLine("Invalid input, please enter a number.");
            }
            userAnswer = Math.Round(userAnswer, 2);
            if (Math.Abs(userAnswer - quotient) < 0.01)
            {
                Console.WriteLine("Congrats you got the answer right");
            }
            else
            {
                Console.WriteLine($"Sorry you got the answer wrong, the correct answer is {quotient}");
            }

            // repeat the game or exit
            Console.WriteLine("Would you like to try again? (Y/N)");
            string? response = Console.ReadLine();
            if (response?.Trim().ToLower() == "y")
            {
                PlayDivisionGame();
            }
            else
            {
                Console.WriteLine("Goodbye!");
                GameMenu.Menu();
            }
        }

    }
}


