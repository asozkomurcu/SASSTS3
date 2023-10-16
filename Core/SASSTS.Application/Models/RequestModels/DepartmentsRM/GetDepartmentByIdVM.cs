using SASSTS.Application.Models.Dtos.CompanyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Models.RequestModels.DepartmentsRM
{
    public class GetDepartmentByIdVM
    {
        public int Id { get; set; }
        public CompanyDto Company { get; set; }
    }
}
