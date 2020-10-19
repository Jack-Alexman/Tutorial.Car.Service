using System;

namespace Tutorial.Car.Common.Exceptions
{
    [Serializable]
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message)
           : base(message)
        {
        }
    }
}
