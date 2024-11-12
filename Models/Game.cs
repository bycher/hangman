using Hangman.Services;
using Spectre.Console;

namespace Hangman.Models
{
    /// <summary>
    /// Сlass representing the process of playing the Hangman
    /// </summary>
    public class Game
    {
        private readonly ConsoleLogger _logger;

        private int _remainingAttempts;
        private readonly HashSet<char> _usedLetters;
        private readonly SecretWord _secretWord;
        private readonly HangmanImage _hangmanImage;

        /// <summary>
        /// The number of remaining attempts to guess the secret word
        /// </summary>
        public int RemainingAttempts => _remainingAttempts;

        /// <summary>
        /// The word that needs to be guessed
        /// </summary>
        public SecretWord SecretWord => _secretWord;

        /// <summary>
        /// The image of the hangman to display in the console
        /// </summary>
        public HangmanImage HangmanImage => _hangmanImage;

        /// <summary>
        /// The set of letters used by the player
        /// </summary>
        public HashSet<char> UsedLetters => _usedLetters;

        /// <summary>
        /// Initializing a new game based on settings
        /// </summary>
        /// <param name="settings">Game settings</param>
        public Game(GameSettings settings)
        {
            _usedLetters = [];
            _remainingAttempts = GameSettings.TotalAttempts;

            var secretWordGenerator = new SecretWordGenerator(settings);
            _secretWord = secretWordGenerator.Generate();

            _hangmanImage = new HangmanImage();

            _logger = new ConsoleLogger(this);
        }

        /// <summary>
        /// Launching a new round of the game
        /// </summary>
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

        /// <summary>
        /// Сhecking the player's guess
        /// </summary>
        /// <param name="letter">The letter used by the player</param>
        /// <returns>true if the letter has not been used before, false otherwise</returns>
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