using Hangman.Models;

namespace Hangman.Services
{
    /// <summary>
    /// A secret word generator based on a text dictionary file
    /// </summary>
    public class SecretWordGenerator
    {
        /// <summary>
        /// A list of possible words
        /// </summary>
        private readonly List<string> _dictionary;

        /// <summary>
        /// Initializing the list of words for the generator
        /// </summary>
        /// <param name="settings">Game settings</param>
        public SecretWordGenerator(GameSettings settings)
        {
            var dictionary = File.ReadAllLines(settings.DictionaryPath);

            _dictionary = dictionary
                .Where(word =>
                    word.Length >= settings.MinWordLength &&
                    word.Length <= settings.MaxWordLength)
                .ToList();
        }

        /// <summary>
        /// Choosing a random word from the dictionary
        /// </summary>
        /// <returns>A random secret word</returns>
        public SecretWord Generate()
        {
            var random = new Random();
            var word = _dictionary[random.Next(_dictionary.Count)];

            return new SecretWord(word);
        }
    }
}