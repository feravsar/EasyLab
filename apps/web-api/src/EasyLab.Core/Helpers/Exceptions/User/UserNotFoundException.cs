using System;
using System.Collections.Generic;
using System.Text;

namespace EasyLab.Core.Helpers.Exceptions.User
{
    public class UserNotFoundException : EasyLabException
    {
        
        public UserNotFoundException(string userIdentifier) : base(typeof(UserNotFoundException).Name, "User not found with identifier:" + userIdentifier)
        {

        }
    }
}
