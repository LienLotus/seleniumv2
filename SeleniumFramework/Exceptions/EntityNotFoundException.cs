using System;

namespace SeleniumFramework.Exceptions
{
    class EntityNotFoundException : Exception
    {
        public EntityNotFoundException()
        {

        }

        public EntityNotFoundException(string message)
            : base(message)
        {

        }
    }
}
