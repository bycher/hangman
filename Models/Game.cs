using Hangman.Services;
using Spectre.Console;

namespace Hangman.Models
{
    public class Game
    {
        private readonly Logger _logger;

        private int _remainingAttempts;
        private readonly HashSet<char> _usedLetters;
        private readonly SecretWord _secretWord;
        private readonly HangmanImage _hangmanImage;

        public int RemainingAttempts => _remainingAttempts;
        public SecretWord SecretWord => _secretWord;
        public HangmanImage HangmanImage => _hangmanImage;
        public HashSet<char> UsedLetters => _usedLetters;

        public Game(GameSettings settings)
        {
            _usedLetters = [];
            _remainingAttempts = GameSettings.TotalAttempts;

            var secretWordGenerator = new SecretWordGenerator(settings);
            _secretWord = secretWordGenerator.Generate();

            _hangmanImage = new HangmanImage();

            _logger = new Logger(this);
        }

        public void Start()
        {
            while (!_secretWord.IsGuessed() && _remainingAttempts > 0)
            {
                _logger.LogRoundInfo();

                bool guessProcessed;
                do
                {
                    var letter = Player.GuessLetter();
                    guessProcessed = ProcessGuess(letter);
                }
                while (!guessProcessed);
            }

            _logger.LogRoundInfo(true);
            _logger.LogGameResult();
        }

        private bool ProcessGuess(char letter)
        {
            if (_usedLetters.Contains(letter))
            {
                AnsiConsole.MarkupLineInterpolated(
                    $"[red]The letter '{letter}' has already been used. Try another one.[/]");
                return false;
            }

            if (_secretWord.Contains(letter))
                _secretWord.RevealLetter(letter);
            else
                _remainingAttempts--;

            _usedLetters.Add(letter);
            return true;
        }
    }
}