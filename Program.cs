using Hangman.Models;
using Spectre.Console.Cli;

namespace Hangman
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            var app = new CommandApp<PlayCommand>();
            return app.Run(args);
        }
    }
}