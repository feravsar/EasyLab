using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace EasyLab.Core.Entities
{
    public class User : IdentityUser<Guid>
    {

        public User()
        {
            RefreshTokens = new List<RefreshToken>();
        }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime DateCreated { get; set; }


        public virtual List<RefreshToken> RefreshTokens { get; set; }

        public virtual List<Assignment> Assignments { get; set; }

        public virtual List<CourseUsers> Courses { get; set; }

        public virtual List<StudentAssignments> StudentAssignments { get; set; }

        public bool HasValidRefreshToken(string refreshToken)
        {
            return RefreshTokens.Any(rt => rt.Token == refreshToken && rt.Active);
        }

        public void AddRefreshToken(string token, Guid userId, string remoteIpAddress, double daysToExpire = 5)
        {
            RefreshTokens.Add(new RefreshToken(token, DateTime.UtcNow.AddDays(daysToExpire), userId, remoteIpAddress));
        }

        public void RemoveRefreshToken(string refreshToken)
        {
            RefreshTokens.Remove(RefreshTokens.First(t => t.Token == refreshToken));            
        }

    }
}