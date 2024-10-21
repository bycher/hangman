using Spectre.Console.Cli;

namespace Hangman
{
    public class GameCommand : Command<GameSettings>
    {
        public override int Execute(CommandContext context, GameSettings settings)
        {
            while (true)
            {
                var option = Player.ChooseStartOption();

                if (option == StartOption.NewGame)
                {
                    var game = new Game(settings);
                    game.Start();
                }
                else if (option == StartOption.Exit)
                    break;
                else
                    Console.WriteLine("Invalid key was pressed. Please try again.");
            }
            
            Console.WriteLine("Goodbye!");
            return 0;
        }
    }
}