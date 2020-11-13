using System;
using System.Collections.Generic;
using System.Text;

namespace EasyLab.Core.Helpers.Exceptions.User
{
    public class EmailNotVerifiedException : EasyLabException
    {
        public EmailNotVerifiedException(string email) : base(typeof(EmailNotVerifiedException).Name , email + " not verified yet.")
        {
        }
    }
}
