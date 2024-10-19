using Hangman;

internal class Program
{
    private static bool ValidateInput(string input)
    {
        if (input.Length != 1)
        {
            Console.WriteLine("You can enter only one letter.");
            return false;
        }
        if (!char.IsAsciiLetter(input[0]))
        {
            Console.WriteLine("Please enter the letter.");
            return false;
        }
        return true;
    }

    private static char ProcessInput()
    {
        string? input;
        do
        {
            Console.Write("Enter the letter: ");
            input = Console.ReadLine()!;
        }
        while (!ValidateInput(input));
        
        return input.First();
    }

    private static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Do you want to start a new game? [y/n]: ");
            var key = Console.ReadKey(true);

            switch (key.KeyChar)
            {
                case 'y':
                    var game = new Game();
                    while (!game.IsGameLost && !game.IsGameWon)
                    {
                        var letter = ProcessInput();
                        game.CheckPlayersAttemp(letter);
                        game.PrintRoundInfo();
                    }
                    break;
                case 'n':
                    return;
                default:
                    Console.WriteLine("Invalid key was pressed, please try again.");
                    break;
            }
        }
    }
}