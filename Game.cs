namespace Hangman
{
    public class Game
    {
        private int _remainingAttempts;
        private readonly List<char> _usedLetters = [];
        private readonly SecretWord _secretWord;

        public Game(GameSettings settings)
        {
            var secretWordGenerator = new SecretWordGenerator(settings);
            _secretWord = secretWordGenerator.GetRandomWord();

            _remainingAttempts = settings.TotalAttempts;
        }

        public void Start()
        {
            while (!_secretWord.IsGuessed() && _remainingAttempts > 0)
            {
                PrintRoundInfo();
                char letter;
                do
                    letter = Player.GuessLetter();
                while (!ProcessGuess(letter));
            }

            PrintFinalMessage();
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

        private void PrintRoundInfo()
        {
            Console.WriteLine("Word: " + _secretWord.Mask);
            Console.WriteLine($"Attempts left: {_remainingAttempts}");
        }

        private void PrintFinalMessage()
        {
            if (_secretWord.IsGuessed())
                Console.Write("Congratulations! You guessed the word: ");
            else
                Console.Write("Unfortunately you have lost! The secret word: ");

            Console.WriteLine(_secretWord.Word);
        }
    }
}