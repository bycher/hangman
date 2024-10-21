using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Hangman
{
    public class GameSettings : CommandSettings
    {
        [CommandOption("-t|--total <TOTAL_ATTEMPTS>")]
        [Description("The total number of attempts to guess the word")]
        [DefaultValue(6)]
        public int TotalAttempts { get; init; }

        [CommandOption("--min <MIN_WORD_LENGTH>")]
        [Description("The minimum length of the secret word")]
        [DefaultValue(5)]
        public int MinWordLength { get; init; }

        [CommandOption("--max <MAX_WORD_LENGTH>")]
        [Description("The maximum length of the secret word")]
        [DefaultValue(10)]
        public int MaxWordLength { get; init; }

        [CommandOption("-f|--file <PATH_TO_DICTIONARY>")]
        [Description("The path to the dictionary file (.txt) for generating the secret word")]
        [DefaultValue("dictionary.txt")]
        public required string Dictionary { get; init; }

        public override ValidationResult Validate()
        {
            if (TotalAttempts <= 0)
                return ValidationResult.Error("The total number of attempts must be positive");
            
            if (MinWordLength <= 0 || MaxWordLength <= 0)
                return ValidationResult.Error("The word length must be positive");

            if (MinWordLength > MaxWordLength)
                return ValidationResult.Error("The minimum word length can't exceed the maximum length");
            
            if (!File.Exists(Dictionary))
            {
                var path = Path.Combine(Environment.CurrentDirectory, Dictionary);
                return ValidationResult.Error($"File '{path}' doesn't exists");
            }

            return ValidationResult.Success();
        }
    }
}