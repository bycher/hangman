namespace Hangman
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                var option = Player.ChooseStartOption();

                if (option == StartOption.NewGame)
                {
                    var settings = new GameSettings();
                    var game = new Game(settings);
                    game.Start();
                }
                else if (option == StartOption.Exit)
                    break;
                else
                    Console.WriteLine("Invalid key was pressed. Please try again.");
            }
            
            Console.WriteLine("Goodbye!");
        }
    }
}