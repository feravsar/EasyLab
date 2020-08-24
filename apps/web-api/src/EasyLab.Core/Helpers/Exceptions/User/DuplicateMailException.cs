using System;
using System.Collections.Generic;
using System.Text;

namespace EasyLab.Core.Helpers.Exceptions.User
{
    public class DuplicateMailException : EasyLabException
    {
        public DuplicateMailException(string email) : base(typeof(DuplicateMailException).Name, "There is already user with email: " + email)
        {
        }
    }
}
