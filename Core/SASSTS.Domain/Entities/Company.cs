using SASSTS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Domain.Entities
{
    public class Company : DeletetableEntity
    {
        public Company()
        {
            Departments = new List<Department>();
        }

        public int? CompanyManagerId { get; set; }
        public string? CompanyManagerName { get; set; }
        public string CompanyName { get; set; }

        public Customer Customer { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
