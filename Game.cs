namespace Hangman
{
    public class Game
    {
        private const int MaxErrorsCount = 6;

        public bool IsGameWon => _secretWord.All(_guessedLetters.Contains);
        public bool IsGameLost => _errorsCount == MaxErrorsCount;

        private readonly SecretWordGenerator _secretWordGenerator;
        private readonly List<char> _guessedLetters;
        private int _errorsCount;
        private readonly string _secretWord;

        public Game(SecretWordGenerator secretWordGenerator)
        {
            _secretWordGenerator = secretWordGenerator;
            _secretWord = _secretWordGenerator.GetRandomWord();
            _guessedLetters = [];
            _errorsCount = 0;
        }

        public void CheckPlayersAttemp(char letter)
        {
            if (_secretWord.Contains(letter))
                _guessedLetters.Add(letter);
            else
                _errorsCount++;
        }

        public void PrintRoundInfo()
        {
            var guessedWord = new string(
                _secretWord.Select(c => _guessedLetters.Contains(c) ? c : '*').ToArray());

            Console.WriteLine($"Word: {guessedWord}");
            Console.WriteLine($"Errors count: {_errorsCount}/{MaxErrorsCount}");

            if (IsGameLost)
                Console.WriteLine("You lost!");
            if (IsGameWon)
                Console.WriteLine("You won!");
        }
    }
}