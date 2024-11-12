using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Hangman.Models
{
    public class GameSettings : CommandSettings
    {
        public const int TotalAttempts = 6;

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
        public required string DictionaryPath { get; init; } = Path.Combine("Data", "dictionary.txt");

        public override ValidationResult Validate()
        {
            if (MinWordLength <= 0 || MaxWordLength <= 0)
                return ValidationResult.Error("The word length must be positive");

            if (MinWordLength > MaxWordLength)
                return ValidationResult.Error("The minimum word length can't exceed the maximum length");

            var fullDictionaryPath = Path.Combine(Environment.CurrentDirectory, DictionaryPath);
            if (!File.Exists(fullDictionaryPath))
                return ValidationResult.Error($"File '{fullDictionaryPath}' doesn't exists");

            return ValidationResult.Success();
        }
    }
}