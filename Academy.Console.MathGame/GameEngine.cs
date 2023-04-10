namespace MathGame
{
    public partial class GameEngine
    {
        

        static void DifficultyChoice()
        {
            Console.WriteLine(@"What difficulty would you like to play at:
            E - Easy
            M - Medium
            H - Hard");
            string? diffSelected = Console.ReadLine()?.Trim().ToLowerInvariant();
            switch (diffSelected)
            {
                case "e":
                GameEngine.PlayGame("Easy");
                break;
                case "m":
                GameEngine.PlayGame("Medium");
                break;
                case "h":
                GameEngine.PlayGame("Hard");
                break;
                
            }
        } 

        static void PlayGame(String difficultyLevel)
        {
            Random random = new Random();
            if (PlayDivisionGame())
            {
                int dividend;
                int divisor;

                switch(difficultyLevel)
                {
                    case "Easy":
                        dividend = random.Next(26);
                        divisor = random.Next(1, 11);
                        break;
                    case "Medium":
                        dividend = random.Next(51);
                        divisor = random.Next(1, 25);
                        break;
                    case "Hard":
                        dividend = random.Next(101);
                        divisor = random.Next(1, 51);                       
                        break;
                    default:
                        throw new ArgumentException("Invalid difficulty level.");
                }
                PlayDivisionGame(dividend, divisor);

            }
            else if (PlayMultiplicationGame())
            {
                int factor1;
                int factor2;

                switch(difficultyLevel)
                {
                    case "Easy":
                        factor1 = random.Next(11);
                        factor2 = random.Next(11);
                        break;
                    case "Medium":
                        factor1 = random.Next(11, 26);
                        factor2 = random.Next(11, 26);
                        break;
                    case "Hard":
                        factor1 = random.Next(26, 51);
                        factor2 = random.Next(26, 51);
                        break;
                    default:
                        throw new ArgumentException("Invalid difficulty level.");
                }
                PlayMultiplicationGame(factor1, factor2);
            }
            else
            {
                double rnd1;
                double rnd2;

                switch(difficultyLevel)
                {
                    case "Easy":
                        rnd1 = random.Next(51);
                        rnd2 = random.Next(51);
                        break;
                    case "Medium":
                        rnd1 = random.Next(101);
                        rnd2 = random.Next(101);
                        break;
                    case "Hard":
                        rnd1 = random.Next(251);
                        rnd2 = random.Next(251);
                        break;
                    default:
                        throw new ArgumentException("Invalid difficulty level.");
                }
                PlayAdditionGame(rnd1, rnd2);
                PlaySubtractionGame(rnd1, rnd2);

            }
        }



            static void ReplayExit()
        {
            // repeat the game or exit
            Console.WriteLine("Would you like to try again? (Y/N)");
            string? response = Console.ReadLine();
            if (response?.Trim().ToLower() == "y")
            {
                // choose current method in use in Program.cs
                Console.WriteLine("Which game would you like to play? Enter 1 for addition, 2 for subtraction, 3 for multiplication, 4 for division:");
                string? gameSelection = Console.ReadLine();
                switch (gameSelection)
                {
                    case "1":
                        PlayAdditionGame();
                        break;
                    case "2":
                        PlaySubtractionGame();
                        break;
                    case "3":
                        PlayMultiplicationGame();
                        break;
                    case "4":
                        PlayDivisionGame();
                        break;
                    default:
                        Console.WriteLine("Invalid game selection.");
                        ReplayExit();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Goodbye!");
                MathGame.GameMenu.Menu();
            }
        }

        public static bool PlayAdditionGame(double rnd1 = 0, double rnd2 = 0, int sum = 0)
        {
            DifficultyChoice();
            while (true)
            {
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
                ReplayExit();
            }
        }

        public static bool PlaySubtractionGame(double rnd1 = 0, double rnd2 = 0, double diff = 0)
        {
            DifficultyChoice();
            while (true)
            {
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
                ReplayExit();
            }
        }

        public static bool PlayMultiplicationGame(int factor1 = 0, int factor2 = 0, int product = 0)
        {
            DifficultyChoice();
            while (true)
            {
                // answering the question and check if it is correct
                Console.WriteLine($"What is {factor1} * {factor2}?");
                if (double.TryParse(Console.ReadLine(), out double ansChk))
                {
                    if (ansChk == product)
                    {
                        Console.WriteLine("Congrats you got the answer right");
                    }
                    else
                    {
                        Console.WriteLine($"Sorry you got the answer wrong, the correct answer is {product}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
                ReplayExit();
            }
        }

        public static bool PlayDivisionGame(int dividend = 0, int divisor = 0, double quotient = 0)
        {
            DifficultyChoice();
            while (true)
            {
                // answering the question and check if it is correct
                Console.WriteLine($"What is {dividend} / {divisor}? (Round to 2 decimal places)");
                if (double.TryParse(Console.ReadLine(), out double ansChk))
                {
                    if (ansChk == quotient)
                    {
                        Console.WriteLine("Congrats you got the answer right");
                    }
                    else
                    {
                        Console.WriteLine($"Sorry you got the answer wrong, the correct answer is {quotient}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
                ReplayExit();
            }


        }

    }
}


