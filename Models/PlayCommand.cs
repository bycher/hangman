using Spectre.Console.Cli;

namespace Hangman.Models
{
    public class PlayCommand : Command<GameSettings>
    {
        public override int Execute(CommandContext context, GameSettings settings)
        {
            while (Player.ConfirmNewGame())
            {
                var game = new Game(settings);
                game.Start();
            }
            return 0;
        }
    }
}