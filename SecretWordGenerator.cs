namespace Hangman
{
    public class SecretWordGenerator
    {
        private const int MinWordLength = 5;
        private const string SourceFile = "words.txt";

        private readonly string[] _words;

        public SecretWordGenerator()
        {
            var allWords = File.ReadAllLines(SourceFile);
            _words = allWords.Where(w => w.Length >= MinWordLength).ToArray();
        }

        public string GetRandomWord()
        {
            var random = new Random();
            return _words[random.Next(_words.Length)];
        }
    }
}