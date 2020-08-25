using System;
using System.Collections.Generic;
using System.Text;

namespace EasyLab.Core.Helpers.Exceptions.User
{
    class InvalidAccessTokenException : EasyLabException
    {
        public InvalidAccessTokenException() : base(typeof(InvalidAccessTokenException).Name, "Access token is invalid")
        {
        }
    }
}
