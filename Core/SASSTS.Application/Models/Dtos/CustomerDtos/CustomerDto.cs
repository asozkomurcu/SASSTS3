using SASSTS.Application.Models.Dtos.DepartmentDtos;
using SASSTS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Models.Dtos.CustomerDtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public string DepartmentName { get; set; }
        public Roles Role { get; set; }
        public UserAuthorizations UserAuthorizations { get; set; }

        public DepartmentDto Department { get; set; }
    }
}
