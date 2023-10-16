using SASSTS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Domain.Services.Abstraction
{
    public interface ILoggedUserService
    {
        int? CustomerId { get; }
        string CustomerName { get; }
        string CustomerSurname { get; }
        string Email { get; }
        Roles? Role { get; }
    }
}
