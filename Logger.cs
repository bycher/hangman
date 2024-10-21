namespace Hangman
{
    public static class Logger
    {
        public static void LogRoundInfo(SecretWord secretWord, int remainingAttempts)
        {
            Console.WriteLine($"Word: {secretWord.Mask}");
            Console.WriteLine($"Attempts left: {remainingAttempts}");
        }

        public static void LogGameResult(SecretWord secretWord)
        {
            if (secretWord.IsGuessed())
                Console.Write("Congratulations! You guessed the word: ");
            else
                Console.Write("Unfortunately you have lost! The secret word: ");

            Console.WriteLine(secretWord.Word);
        }
    }
}