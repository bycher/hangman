namespace Hangman
{
    public class Game
    {
        private readonly int _maxErrorsCount;
        private int _errorsCount;
        private readonly List<char> _usedLetters = [];
        private readonly SecretWord _secretWord;

        public Game(int maxErrorsCount)
        {
            _maxErrorsCount = maxErrorsCount;

            var secretWordGenerator = new SecretWordGenerator();
            _secretWord = secretWordGenerator.GetRandomWord();
        }

        public void Start()
        {
            while (!_secretWord.IsGuessed() && _errorsCount < _maxErrorsCount)
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
                _secretWord.Reveal(letter);
            else
                _errorsCount++;

            _usedLetters.Add(letter);
            return true;
        }

        private void PrintRoundInfo()
        {
            Console.WriteLine("Word: " + _secretWord.Mask);
            Console.WriteLine($"Errors count: {_errorsCount}/{_maxErrorsCount}");
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