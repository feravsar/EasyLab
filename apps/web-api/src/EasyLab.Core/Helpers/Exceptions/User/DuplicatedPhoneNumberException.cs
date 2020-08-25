using System;
using System.Collections.Generic;
using System.Text;

namespace EasyLab.Core.Helpers.Exceptions.User
{
    public class DuplicatedPhoneNumberException : EasyLabException
    {
        public DuplicatedPhoneNumberException(string phoneNumber) : base(typeof(DuplicatedPhoneNumberException).Name, "There is already user with email: " + phoneNumber)
        {
        }
    }
}
