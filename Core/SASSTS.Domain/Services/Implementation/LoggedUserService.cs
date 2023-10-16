using Microsoft.AspNetCore.Http;
using SASSTS.Domain.Services.Abstraction;
using SASSTS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Domain.Services.Implementation
{
    public class LoggedUserService : ILoggedUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoggedUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int? CustomerId => GetClaim(ClaimTypes.PrimarySid) != null ? int.Parse(GetClaim(ClaimTypes.PrimarySid)) : null;
        public string CustomerName => GetClaim(ClaimTypes.Name) != null ? GetClaim(ClaimTypes.Name) : null;
        public string CustomerSurname => GetClaim(ClaimTypes.Surname) != null ? GetClaim(ClaimTypes.Surname) : null;
        public string Email => GetClaim(ClaimTypes.Email) != null ? GetClaim(ClaimTypes.Email) : null;
        public Roles? Role => GetClaim(ClaimTypes.Role) != null ? (Roles)Enum.Parse(typeof(Roles), GetClaim(ClaimTypes.Role)) : null;


        private string GetClaim(string claimType)
        {
            return _httpContextAccessor?.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == claimType)?.Value;
        }
    }
}
