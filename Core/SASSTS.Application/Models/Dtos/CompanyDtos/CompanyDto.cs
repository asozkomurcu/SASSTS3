using SASSTS.Application.Models.Dtos.CustomerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Models.Dtos.CompanyDtos
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public int? CompanyManagerId { get; set; }
        public string? CompanyManagerName { get; set; }
        public string CompanyName { get; set; }

        public CustomerDto Customer { get; set; }
    }
}
