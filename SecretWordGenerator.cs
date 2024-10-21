namespace Hangman
{
    public class SecretWordGenerator
    {
        private readonly List<string> _dictionary;

        public SecretWordGenerator(GameSettings settings)
        {
            var dictionary = File.ReadAllLines(settings.Dictionary);

            _dictionary = dictionary.Where(w =>
                w.Length >= settings.MinWordLength &&
                w.Length <= settings.MaxWordLength).ToList();
        }

        public SecretWord GetRandomWord()
        {
            var random = new Random();
            var word = _dictionary[random.Next(_dictionary.Count)];

            return new SecretWord(word);
        }
    }
}