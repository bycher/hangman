using Spectre.Console.Cli;

namespace Hangman
{
    public class GameCommand : Command<GameSettings>
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