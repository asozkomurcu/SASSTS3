using SASSTS.Application.Models.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Models.Dtos.ProductDtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public decimal Amount { get; set; }
        public decimal UnitPrice { get; set; }

        public CategoryDto Category { get; set; }

    }
}
