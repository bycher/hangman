using Spectre.Console;

namespace Hangman
{
    public class Game
    {
        private int _remainingAttempts;
        private readonly HashSet<char> _usedLetters;
        private readonly SecretWord _secretWord;
        private readonly HangmanImage _hangmanImage;

        public Game(GameSettings settings)
        {
            _usedLetters = [];
            _remainingAttempts = GameSettings.TotalAttempts;

            var secretWordGenerator = new SecretWordGenerator(settings);
            _secretWord = secretWordGenerator.GetRandomWord();

            _hangmanImage = new HangmanImage();
        }

        public void Start()
        {
            while (!_secretWord.IsGuessed() && _remainingAttempts > 0)
            {
                Logger.LogRoundInfo(_secretWord, _remainingAttempts, _usedLetters, _hangmanImage);
                bool processed;
                do
                {
                    var letter = Player.GuessLetter();
                    processed = ProcessGuess(letter);
                }
                while (!processed);
            }

            Logger.LogRoundInfo(_secretWord, _remainingAttempts, _usedLetters, _hangmanImage, true);
            Logger.LogGameResult(_secretWord);
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