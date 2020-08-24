using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace EasyLab.Core.Entities
{
    public class User : IdentityUser
    {

        public User()
        {
            RefreshTokens = new List<RefreshToken>();
            VerificationCodes = new List<VerificationCode>();
        }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string CompanyName { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual List<RefreshToken> RefreshTokens { get; set; }

        public virtual List<VerificationCode> VerificationCodes { get; set; }

        public bool HasValidRefreshToken(string refreshToken)
        {
            return RefreshTokens.Any(rt => rt.Token == refreshToken && rt.Active);
        }

        public void AddRefreshToken(string token, string userId, string remoteIpAddress, double daysToExpire = 5)
        {
            RefreshTokens.Add(new RefreshToken(token, DateTime.UtcNow.AddDays(daysToExpire), userId, remoteIpAddress));
        }

        public void RemoveRefreshToken(string refreshToken)
        {
            RefreshTokens.Remove(RefreshTokens.First(t => t.Token == refreshToken));
        }

    }
}