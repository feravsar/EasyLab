using System;
using System.Collections.Generic;
using System.Text;

namespace EasyLab.Core.Interfaces.Services
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);

        bool VerifyHashedPassword(string hashedPassword, string providedPassword);
    }
}
