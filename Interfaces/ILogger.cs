namespace Hangman.Interfaces
{
    interface ILogger
    {
        void LogRoundInfo(bool revealWord);
        void LogGameResult();
    }
}