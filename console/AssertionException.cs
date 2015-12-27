namespace console
{
    using System;

    public class AssertionException : Exception
    {
        public AssertionException(string message) : base(message)
        {
        }
    }
}