using System;
using EasyLab.Core.Interfaces.Services;

namespace EasyLab.Infrastructure.Auth
{
    internal sealed class VerificationCodeFactory : IVerificationCodeFactory
    {
        private readonly char[] alphabet = new char[] 
        { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public string GenerateVerificationCode()
        {
            string verificationCode = string.Empty;
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
              verificationCode += alphabet[random.Next(36)]; 
            }
            return verificationCode;
        }
    }

}