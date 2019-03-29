using System;

namespace Mews.Fiscalization.Uniwix.Exceptions
{
    public class UniwixAuthorizationException : Exception
    {
        public UniwixAuthorizationException()
            : base ("Uniwix authorization failed.")
        {
        }
    }
}