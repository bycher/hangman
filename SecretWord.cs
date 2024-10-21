#pragma warning disable IDE0290

namespace Hangman
{
    public class SecretWord
    {
        private const char UnknownLetterPlaceholder = '*';

        private readonly List<char> _mask;
        private readonly string _word;

        public string Word => _word;
        public string Mask => new([.. _mask]);

        public SecretWord(string word)
        {
            _word = word;
            _mask = Enumerable.Repeat(UnknownLetterPlaceholder, word.Length).ToList();
        }

        public bool IsGuessed() => _mask.SequenceEqual(_word);

        public bool Contains(char letter) => _word.Contains(letter);

        public void RevealLetter(char letter)
        {
            for (var i = 0; i < _word.Length; i++)
                if (_word[i] == letter)
                    _mask[i] = letter;
        }
    }
}