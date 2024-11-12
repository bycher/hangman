#pragma warning disable IDE0290

using Hangman.Models;
using Spectre.Console;

namespace Hangman.Services
{
    public class Logger
    {
        private readonly Game _game;

        public Logger(Game game)
        {
            _game = game;
        }

        public void LogRoundInfo(bool revealWord = false)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new Rule("[yellow]Hangman[/]"));

            PrintHangmanImage();
            PrintWordPanel(revealWord);
            PrintStatistics();
        }

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