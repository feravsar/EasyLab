using System;
using System.Collections.Generic;
using System.Text;

namespace EasyLab.Core.Entities
{
    public class VerificationCode
    {

        public string Id { get; set; }

        public string  Code { get; set; }

        public string UserId { get; set; }

        public DateTime Expires { get; set; }

        public int VerificationCodeType { get; set; }

        public DateTime? VerificatedTime { get; set; }

        public bool IsCancelled { get; set; }

        public string VerificatedIpAddress { get; set; }



        public virtual User User { get; set; }
    }
}
