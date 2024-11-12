using Hangman.Models;

namespace Hangman.Services
{
    public class SecretWordGenerator
    {
        private readonly List<string> _dictionary;

        public SecretWordGenerator(GameSettings settings)
        {
            var dictionary = File.ReadAllLines(settings.DictionaryPath);

            _dictionary = dictionary
                .Where(word =>
                    word.Length >= settings.MinWordLength &&
                    word.Length <= settings.MaxWordLength)
                .ToList();
        }

        public SecretWord Generate()
        {
            var random = new Random();
            var word = _dictionary[random.Next(_dictionary.Count)];

            return new SecretWord(word);
        }
    }
}