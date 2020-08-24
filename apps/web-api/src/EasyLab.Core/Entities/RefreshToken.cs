using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLab.Core.Entities{
    public class RefreshToken{
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Token { get; private set; }
        public DateTime Expires { get; private set; }
        public string UserId { get; private set; }


        public virtual User User {get; set;}

        public bool Active => DateTime.UtcNow <= Expires;
        public string RemoteIpAddress { get; private set; }

         public RefreshToken(string token, DateTime expires,string userId,string remoteIpAddress)
        {
            Token = token;
            Expires = expires;
            UserId = userId;
            RemoteIpAddress = remoteIpAddress;
        }
    }
}
