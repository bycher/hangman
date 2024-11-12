using Spectre.Console;

namespace Hangman.Models
{
    public static class Player
    {
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

        public static char GuessLetter()
        {
            var input = AnsiConsole.Prompt(
                new TextPrompt<string>("[yellow]Enter the letter[/]: ")
                    .Validate(ValidateInput));

            return input[0];
        }

        public static bool ConfirmNewGame() => AnsiConsole.Prompt(
            new TextPrompt<bool>("Do you want to start a new game?")
                .AddChoices([true, false])
                .DefaultValue(true)
                .WithConverter(choice => choice ? "y" : "n"));
    }
}