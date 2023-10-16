using SASSTS.Application.Models.Dtos.DepartmentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Models.RequestModels.CustomerRM
{
    public class GetCustomerByIdVM
    {
        public int Id { get; set; }

        public DepartmentDto Department { get; set; }
    }
}
