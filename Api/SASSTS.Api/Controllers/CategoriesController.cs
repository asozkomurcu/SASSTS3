using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SASSTS.Application.Models.Dtos.CategoryDtos;
using SASSTS.Application.Models.Dtos.CustomerDtos;
using SASSTS.Application.Models.RequestModels.CategoriesRM;
using SASSTS.Application.Services.Abstraction;
using SASSTS.Application.Wrapper;
using SASSTS.Domain.Entities;

namespace SASSTS.Api.Controllers
{
    [Route("category")]
    [ApiController]
    //[Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("get")]
        //[AllowAnonymous]
        public async Task<ActionResult<List<CategoryDto>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("get/{id:int}")]
        //[AllowAnonymous]
        public async Task<ActionResult<Result<CustomerDto>>> GatAllCustomerById(int id)
        {
            var category = await _categoryService.GetCategoryById(new GetCategoryByIdVM { Id = id });
            return Ok(category);
        }

        [HttpPost("create")]
        //[Authorize(Roles = "ProductManager")]
        public async Task<ActionResult<Result<int>>> CreateCategory(CreateCategoryVM createCategoryVM)
        {
            var categoryId = await _categoryService.CreateCategory(createCategoryVM);
            return Ok(categoryId);
        }

        [HttpDelete("delete")]
        //[Authorize(Roles = "ProductManager")]
        public async Task<ActionResult<Result<int>>> DeleteCategory(DeleteCategoryVM deleteCategoryVM)
        {
            var categoryId = await _categoryService.DeleteCategory(deleteCategoryVM);
            return Ok(categoryId);
        }

        [HttpPost("update/{id:int}")]
        //[Authorize(Roles = "ProductManager")]
        public async Task<ActionResult<Result<int>>> UpdateCategory(int id, UpdateCategoryVM updateCategoryVM)
        {
            if (id != updateCategoryVM.Id)
            {
                return BadRequest();
            }

            var categoryId = await _categoryService.UpdateCategory(updateCategoryVM);
            return Ok(categoryId);
        }
    }
}
