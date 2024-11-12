using Spectre.Console;

namespace Hangman.Models
{
    /// <summary>
    /// A class representing the player's actions
    /// </summary>
    public static class Player
    {
        /// <summary>
        /// Validation of player's input
        /// </summary>
        /// <param name="input">Сonsole input</param>
        /// <returns>ValidationResult object representing error / success</returns>
        private static ValidationResult ValidateInput(string input)
        {
            if (input.Length != 1)
                return ValidationResult.Error("[red]You need to enter one letter[/]");

            var letter = input[0];

            if (!char.IsLetter(letter))
                return ValidationResult.Error("[red]You need to enter the letter[/]");
            if (!char.IsLower(letter))
                return ValidationResult.Error("[red]Only lowercase letters are allowed[/]");

            return ValidationResult.Success();
        }

        /// <summary>
        /// Propmpt for the next letter from the user
        /// </summary>
        /// <returns>The entered letter</returns>
        public static char GuessLetter()
        {
            var input = AnsiConsole.Prompt(
                new TextPrompt<string>("[yellow]Enter the letter[/]: ")
                    .Validate(ValidateInput));

            return input[0];
        }

        /// <summary>
        /// Prompt confirming the start of a new game
        /// </summary>
        /// <returns>true if the user press 'y', false if 'n' was pressed</returns>
        public static bool ConfirmNewGame() => AnsiConsole.Prompt(
            new TextPrompt<bool>("Do you want to start a new game?")
                .AddChoices([true, false])
                .DefaultValue(true)
                .WithConverter(choice => choice ? "y" : "n"));
    }
}