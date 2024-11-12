using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Hangman.Models
{
    /// <summary>
    /// A game settings containing command line arguments that are set when the program starts
    /// </summary>
    public class GameSettings : CommandSettings
    {
        public const int TotalAttempts = 6;

        /// <summary>
        /// The minimum length of the secret word
        /// Default: 5
        /// </summary>
        [CommandOption("--min <MIN_WORD_LENGTH>")]
        [Description("The minimum length of the secret word")]
        [DefaultValue(5)]
        public int MinWordLength { get; init; }

        /// <summary>
        /// The maximum length of the secret word
        /// Default: 10
        /// </summary>
        [CommandOption("--max <MAX_WORD_LENGTH>")]
        [Description("The maximum length of the secret word")]
        [DefaultValue(10)]
        public int MaxWordLength { get; init; }

        /// <summary>
        /// The path to the dictionary file (.txt) for generating the secret word
        /// Default location: Data/dictionary.txt
        /// </summary>
        [CommandOption("-f|--file <PATH_TO_DICTIONARY>")]
        [Description("The path to the dictionary file (.txt) for generating the secret word")]
        public required string DictionaryPath { get; init; } = Path.Combine("Data", "dictionary.txt");

        /// <summary>
        /// Validating command line arguments
        /// </summary>
        /// <returns>ValidationResult object (error or success)</returns>
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