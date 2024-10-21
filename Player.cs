namespace Hangman
{
    public static class Player
    {
        private static bool IsValidInput(string input)
        {
            if (input.Length != 1)
            {
                Console.WriteLine("You need to enter one letter");
                return false;
            }

            var symbol = input[0];
            if (!char.IsLetter(symbol))
            {
                Console.WriteLine("You need to enter the letter");
                return false;
            }
            if (!char.IsLower(symbol))
            {
                Console.WriteLine("Only lowercase letters are allowed");
                return false;
            }
            return true;
        }

        public static char GuessLetter()
        {
            string input;
            do
            {
                Console.Write("Enter the letter: ");
                input = Console.ReadLine()!;
            }
            while (!IsValidInput(input));

            return input[0];
        }

        public static StartOption ChooseStartOption()
        {
            Console.Write("Do you want to start a new game? [y/n]: ");
            var key = Console.ReadKey();
            Console.WriteLine();

            return key.KeyChar switch
            {
                'y' => StartOption.NewGame,
                'n' => StartOption.Exit,
                _ => StartOption.Unknown
            };
        }
    }

    public enum StartOption
    {
        NewGame,
        Exit,
        Unknown
    }
}