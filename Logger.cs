using Spectre.Console;

namespace Hangman
{
    public static class Logger
    {
        private static void PrintWordPanel(SecretWord secretWord, bool revealWord = false)
        {
            var word = revealWord ? secretWord.Word : secretWord.Mask;
            var panel = new Panel(string.Join(" ", word.AsEnumerable()))
            {
                Padding = new Padding(2, 1)
            };

            AnsiConsole.Write(new Padder(Align.Center(panel)).PadTop(1));
        }

        private static void PrintStatistics(int remainingAttempts, HashSet<char> usedLetters)
        {
            AnsiConsole.MarkupLineInterpolated(
                $"[yellow]Attempts left[/]: {remainingAttempts}");
            AnsiConsole.MarkupLineInterpolated(
                $"[yellow]Used letters[/]: [[ {string.Join(", ", usedLetters)} ]]");
            AnsiConsole.WriteLine();
        }

        public static void LogRoundInfo(
            SecretWord secretWord, int remainingAttempts, HashSet<char> usedLetters, bool revealWord = false)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new Rule("[yellow]Hangman[/]"));

            PrintWordPanel(secretWord, revealWord);
            PrintStatistics(remainingAttempts, usedLetters);
        }

        public static void LogGameResult(SecretWord secretWord)
        {
            var text = secretWord.IsGuessed()
                ? "Congratulations! You guessed the word!\n"
                : $"Sorry but you lost! The secret word was '{secretWord.Word}'.\n";

            AnsiConsole.WriteLine(text);
        }
    }
}