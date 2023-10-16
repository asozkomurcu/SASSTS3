using SASSTS.Application.Models.Dtos.CompanyDtos;
using SASSTS.Application.Models.Dtos.CustomerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Models.Dtos.DepartmentDtos
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public int? DepartmentManagerId { get; set; }
        public int CompanyId { get; set; }
        public string? DepartmentManagerName { get; set; }
        public string DepartmentName { get; set; }
        public string CompanyName { get; set; }

        public CompanyDto Company { get; set; }
        public CustomerDto Customer { get; set; }
    }
}
