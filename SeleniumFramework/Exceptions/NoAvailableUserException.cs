using System;

namespace SeleniumFramework.Exceptions
{
    class NoAvailableUserException : Exception
    {
        public NoAvailableUserException()
        {

        }

        public NoAvailableUserException(string message)
            : base(message)
        {

        }
    }
}
