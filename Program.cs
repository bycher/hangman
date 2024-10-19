using Hangman;

internal class Program
{
    private static bool ValidateInput(string? input)
    {
        if (input == null)
            return false;

        if (input.Length != 1)
            return false;

        return char.IsAsciiLetter(input[0]);
    }

    private static void Main(string[] args)
    {
        do
        {
            Console.WriteLine("Хотите начать новую игру [y/n]?");
            var key = Console.ReadKey(true);
            if (key.KeyChar == 'y')
            {
                var game = new Game();
                while (true)
                {
                    string? input;
                    do
                    {
                        Console.WriteLine("Введите букву:");
                        input = Console.ReadLine();
                    }
                    while (!ValidateInput(input));
                    
                    var letter = input!.First();
                    game.CheckLetter(letter);

                    if (game.IsMaxErrorCountReached())
                    {
                        Console.WriteLine("Вы проиграли");
                        break;
                    }

                    if (game.IsWordGuessed())
                    {
                        Console.WriteLine("Вы победили");
                        break;
                    }
                }
            }
            else if (key.KeyChar == 'n')
            {
                return;
            }
            else
            {
                Console.WriteLine("Введите 'y', чтобы начать новую игру, или 'n', чтобы выйти из приложения.");
            }
        }
        while (true);
    }
}