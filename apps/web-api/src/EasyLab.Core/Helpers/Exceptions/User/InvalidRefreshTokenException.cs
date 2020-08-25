using System;
using System.Collections.Generic;
using System.Text;

namespace EasyLab.Core.Helpers.Exceptions.User
{
    public class InvalidRefreshTokenException : EasyLabException
    {
        public InvalidRefreshTokenException() : base(typeof(InvalidRefreshTokenException).Name, "The requested refresh token never existed or it's expired.")
        {
        }
    }
}
