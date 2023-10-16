using SASSTS.Application.Models.Dtos.ProductDtos;
using SASSTS.Application.Models.RequestModels.ProductsRM;
using SASSTS.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Services.Abstraction
{
    public interface IProductService
    {
        Task<Result<List<ProductDto>>> GetAllProducts();
        Task<Result<ProductDto>> GetProductById(GetProductByIdVM getProductByIdVM);
        Task<Result<int>> CreateProduct(CreateProductVM createProductVM);
        Task<Result<int>> UpdateProduct(UpdateProductVM updateProductVM);
        Task<Result<int>> DeleteProduct(DeleteProductVM deleteProductVM);
    }
}
