using System;
using System.Collections.Generic;
using System.Text;

namespace EasyLab.Core.Helpers.Exceptions
{
    public abstract class EasyLabException : Exception
    {
        public readonly string Code;

        public EasyLabException(string code, string message) : base(message)
        {
            Code = code;
        } 

    }
}
