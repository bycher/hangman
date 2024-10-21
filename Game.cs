namespace Hangman
{
    public class Game
    {
        private int _remainingAttempts;
        private readonly HashSet<char> _usedLetters;
        private readonly SecretWord _secretWord;

        public Game(GameSettings settings)
        {
            _usedLetters = [];
            _remainingAttempts = settings.TotalAttempts;

            var secretWordGenerator = new SecretWordGenerator(settings);
            _secretWord = secretWordGenerator.GetRandomWord();
        }

        public void Start()
        {
            while (!_secretWord.IsGuessed() && _remainingAttempts > 0)
            {
                Logger.LogRoundInfo(_secretWord, _remainingAttempts);
                char letter;
                do
                    letter = Player.GuessLetter();
                while (!ProcessGuess(letter));
            }

            Logger.LogGameResult(_secretWord);
        }

        private bool ProcessGuess(char letter)
        {
            if (_usedLetters.Contains(letter))
            {
                Console.WriteLine($"Letter '{letter}' has already been used. Try another letter.");
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