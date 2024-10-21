namespace Hangman
{
    public class SecretWord(string word)
    {
        private const char UnknownLetterPlaceholder = '*';

        private readonly List<char> _mask =
            Enumerable.Repeat(UnknownLetterPlaceholder, word.Length).ToList();
        private readonly string _word = word;

        public string Word => _word;
        public string Mask => new([.. _mask]);

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