using SASSTS.Application.Models.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Models.RequestModels.ProductsRM
{
    public class GetProductByIdVM
    {
        public int Id { get; set; }

        public CategoryDto Category { get; set; }
    }
}
