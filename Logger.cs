namespace Hangman
{
    public static class Logger
    {
        public static void LogRoundInfo(
            SecretWord secretWord, int remainingAttempts, HashSet<char> usedLetters)
        {
            Console.WriteLine($"Word: {secretWord.Mask}");
            Console.WriteLine($"Attempts left: {remainingAttempts}");
            Console.WriteLine($"Used letters: [ {string.Join(", ", usedLetters)} ]");
        }

        public static void LogGameResult(SecretWord secretWord)
        {
            if (secretWord.IsGuessed())
                Console.Write("Congratulations! You guessed the word: ");
            else
                Console.Write("Unfortunately, you lost! The secret word was: ");

            Console.WriteLine(secretWord.Word);
        }
    }
}