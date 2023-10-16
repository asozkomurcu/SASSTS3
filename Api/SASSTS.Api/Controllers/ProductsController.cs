using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SASSTS.Application.Models.Dtos.ProductDtos;
using SASSTS.Application.Models.RequestModels.ProductsRM;
using SASSTS.Application.Services.Abstraction;
using SASSTS.Application.Wrapper;

namespace SASSTS.Api.Controllers
{
    [Route("product")]
    [ApiController]
    //[Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("get")]
        //[AllowAnonymous]
        public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("get/{id:int}")]
        //[AllowAnonymous]
        public async Task<ActionResult<Result<ProductDto>>> GetProductById(int id)
        {
            var product = await _productService.GetProductById(new GetProductByIdVM { Id = id });
            return Ok(product);
        }

        [HttpPost("create")]
        //[Authorize(Roles = "ProductManager")]
        public async Task<ActionResult<Result<int>>> CreateProduct(CreateProductVM createProductVM)
        {
            var productId = await _productService.CreateProduct(createProductVM);
            return Ok(productId);
        }

        [HttpDelete("delete")]
        //[Authorize(Roles = "ProductManager")]
        public async Task<ActionResult<Result<int>>> DeleteProduct(DeleteProductVM deleteProductVM)
        {
            var productId = await _productService.DeleteProduct(deleteProductVM);
            return Ok(productId);
        }

        [HttpPost("update/{id:int}")]
        //[Authorize(Roles = "ProductManager")]
        public async Task<ActionResult<Result<int>>> UpdateProduct(int id, UpdateProductVM updateProductVM)
        {
            if (id != updateProductVM.Id)
            {
                return BadRequest();
            }

            var productId = await _productService.UpdateProduct(updateProductVM);
            return Ok(productId);
        }
    }
}
