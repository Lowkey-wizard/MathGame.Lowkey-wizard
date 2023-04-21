namespace Academy.Console.MathGame.Models;
internal class Game
{
    private static int correctAnswers;
    private static int incorrectAnswers;

    internal static void Score(bool isCorrect)
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
    internal static int CorrectAnswers { get => correctAnswers; set => correctAnswers = value; }
    internal static int IncorrectAnswers { get => incorrectAnswers; set => incorrectAnswers = value; }
}
