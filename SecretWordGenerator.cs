namespace Hangman
{
    public class SecretWordGenerator
    {
        private const string SourceFile = "words.txt";

        private readonly List<string> _words;

        public SecretWordGenerator(GameSettings gameSettings)
        {
            var allWords = File.ReadAllLines(SourceFile);
            _words = allWords.Where(w =>
                w.Length >= gameSettings.MinWordLength &&
                w.Length <= gameSettings.MaxWordLength).ToList();
        }

        public SecretWord GetRandomWord()
        {
            var random = new Random();
            var word = _words[random.Next(_words.Count)];

            return new SecretWord(word);
        }
    }
}