namespace Hangman
{
    public class Game
    {
        public const int MaxErrors = 6;

        public int ErrorsCount { get; set; }
        public string SecretWord { get; set; } = null!;
        public List<char> GuessedLetters { get; set; } = [];

        public Game()
        {
            SecretWord = "SECRET";
        }

        public bool IsWordGuessed()
        {
            return GuessedLetters.Count == SecretWord.Length;
        }

        public bool IsMaxErrorCountReached()
        {
            return ErrorsCount == MaxErrors;
        }

        public void CheckLetter(char letter)
        {
            Console.Write("Слово: ");
            if (SecretWord.Contains(letter))
            {
                GuessedLetters.AddRange(Enumerable.Repeat(letter, SecretWord.Count(c => c == letter)));
                foreach (var c in SecretWord)
                {
                    if (GuessedLetters.Contains(c))
                        Console.Write(c);
                    else
                        Console.Write("*");
                }
            }
            else
            {
                ErrorsCount++;
            }
            Console.WriteLine();
            Console.WriteLine($"Число ошибок: {ErrorsCount}/{MaxErrors}");
        }

    }
}