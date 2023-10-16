using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Models.RequestModels.AccountsRM
{
    public class UpdateUserVM
    {
        public int? Id { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string Password { get; set; }

    }
}
