#pragma warning disable IDE0290

using Hangman.Interfaces;
using Hangman.Models;
using Spectre.Console;

namespace Hangman.Services
{
    /// <summary>
    /// A console logging service
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        private readonly Game _game;

        /// <summary>
        /// Сreating a logger based on a Game's object
        /// </summary>
        /// <param name="game">Game object</param>
        public ConsoleLogger(Game game)
        {
            _game = game;
        }

        /// <summary>
        /// Logging information about the round to the console. It logs:
        ///   - the image of the hangman
        ///   - the guessed letters
        ///   - statistics
        /// </summary>
        /// <param name="revealWord">Is it required to reveal the word</param>
        public void LogRoundInfo(bool revealWord = false)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new Rule("[yellow]Hangman[/]"));

            PrintHangmanImage();
            PrintWordPanel(revealWord);
            PrintStatistics();
        }

        /// <summary>
        /// Logging the final message to the console
        /// </summary>
        public void LogGameResult()
        {
            var text = _game.SecretWord.IsGuessed()
                ? "Congratulations! You guessed the word!\n"
                : $"Sorry but you lost! The secret word was '{_game.SecretWord.Word}'.\n";

            AnsiConsole.WriteLine(text);
        }

        private void PrintHangmanImage()
        {
            _game.HangmanImage.Update(_game.RemainingAttempts);
            AnsiConsole.Write(Align.Center(new Text(_game.HangmanImage.Image)));
        }

        private void PrintWordPanel(bool revealWord)
        {
            var word = revealWord ? _game.SecretWord.Word : _game.SecretWord.Mask;
            var panel = new Panel(string.Join(" ", word.AsEnumerable()))
            {
                Padding = new Padding(2, 1)
            };

            AnsiConsole.Write(new Padder(Align.Center(panel)).PadTop(1));
        }

        private void PrintStatistics()
        {
            AnsiConsole.MarkupLineInterpolated(
                $"[green]Attempts left[/]: {_game.RemainingAttempts}");
            AnsiConsole.MarkupLineInterpolated(
                $"[green]Used letters[/] : [[ {string.Join(", ", _game.UsedLetters)} ]]");
            AnsiConsole.WriteLine();
        }
    }
}