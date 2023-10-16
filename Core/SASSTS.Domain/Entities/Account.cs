using SASSTS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Domain.Entities
{
    public class Account : BaseEntity
    {
        public int CustomerId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string? LastUserIp { get; set; }

        public Customer Customer { get; set; }


    }


}
