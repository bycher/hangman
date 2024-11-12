#pragma warning disable IDE0290

namespace Hangman.Models
{
    /// <summary>
    /// The secret word that player needs to guess
    /// </summary>
    public class SecretWord
    {
        private const char UnknownLetterPlaceholder = '_';

        private readonly List<char> _mask;
        private readonly string _word;

        /// <summary>
        /// The secret word
        /// </summary>
        public string Word => _word;

        /// <summary>
        /// The masked secret word
        /// </summary>
        public string Mask => new([.. _mask]);

        /// <summary>
        /// Сreating a secret word (and mask) based on a given string
        /// </summary>
        /// <param name="word">A given string</param>
        public SecretWord(string word)
        {
            _word = word;
            _mask = Enumerable.Repeat(UnknownLetterPlaceholder, word.Length).ToList();
        }

        /// <summary>
        /// Сhecking whether the word is guessed
        /// </summary>
        /// <returns>true if the word is guessed, false otherwise</returns>
        public bool IsGuessed() => _mask.SequenceEqual(_word);

        /// <summary>
        /// Сhecking whether a letter is contained in a word
        /// </summary>
        /// <param name="letter">The letter</param>
        /// <returns>true if the letter is contained in the word, false otherwise</returns>
        public bool Contains(char letter) => _word.Contains(letter);

        /// <summary>
        /// revealing a successfully guessed letter in a mask
        /// </summary>
        /// <param name="letter">The letter</param>
        public void RevealLetter(char letter)
        {
            for (var i = 0; i < _word.Length; i++)
                if (_word[i] == letter)
                    _mask[i] = letter;
        }
    }
}