using System;
using System.Collections.Generic;
using System.Text;

namespace EasyLab.Core.Helpers.Exceptions.User
{
    public class VerificationCodeInvalidException : EasyLabException
    {
        public VerificationCodeInvalidException() : base(typeof(VerificationCodeInvalidException).Name, "The requested verification code never existed or it's expired.")
        {
        }
    }
}
