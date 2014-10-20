namespace AgetotonRPG.Exceptions
{
    using System;

    public abstract class GameException : Exception
    {
        protected GameException(string message)
            : base(message)
        {
        }
    }
}