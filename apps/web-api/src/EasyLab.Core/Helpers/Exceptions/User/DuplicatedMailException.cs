using System;
using System.Collections.Generic;
using System.Text;

namespace EasyLab.Core.Helpers.Exceptions.User
{
    public class DuplicatedMailException : EasyLabException
    {
        public DuplicatedMailException(string email) : base(typeof(DuplicatedMailException).Name, "There is already user with email: " + email)
        {
        }
    }
}
