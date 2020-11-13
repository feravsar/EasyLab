using System;
using System.Collections.Generic;
using System.Text;

namespace EasyLab.Core.Helpers.Exceptions.User
{
    public class UsernameOrPasswordWrongException : EasyLabException
    {
        public UsernameOrPasswordWrongException() : base(typeof(UsernameOrPasswordWrongException).Name, "Username or password is incorrect.")
        {
        }
    }
}
