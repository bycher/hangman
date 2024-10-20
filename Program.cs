namespace Hangman
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                var option = Player.ChooseStartOption();

                if (option == 'y')
                {
                    var game = new Game(6);
                    game.Start();
                }
                else if (option == 'n')
                    break;
                else
                    Console.WriteLine("Invalid key was pressed. Please try again.");
            }
        }
    }
}