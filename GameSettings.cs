namespace Hangman
{
    public class GameSettings
    {
        private const int TotalAttemptsDefault = 6;
        private const int MinWordLengthDefault = 5;
        private const int MaxWordLengthDefault = 10;

        public int TotalAttempts { get; set; } = TotalAttemptsDefault;
        public int MinWordLength { get; set; } = MinWordLengthDefault;
        public int MaxWordLength { get; set; } = MaxWordLengthDefault;
    }
}