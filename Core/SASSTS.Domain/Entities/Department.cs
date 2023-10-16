using SASSTS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Domain.Entities
{
    public class Department : DeletetableEntity
    {
        public int? DepartmentManagerId { get; set; }
        public int CompanyId { get; set; }
        public string? DepartmentManagerName { get; set; }
        public string DepartmentName { get; set; }
        public string CompanyName { get; set; }

        public Company Company { get; set; }
        public Customer Customer { get; set; }
    }
}
