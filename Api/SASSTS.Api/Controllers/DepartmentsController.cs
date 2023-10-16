using Microsoft.AspNetCore.Mvc;
using SASSTS.Application.Models.Dtos.DepartmentDtos;
using SASSTS.Application.Models.RequestModels.DepartmentsRM;
using SASSTS.Application.Services.Abstraction;
using SASSTS.Application.Wrapper;

namespace SASSTS.Api.Controllers
{
    [Route("department")]
    [ApiController]
    //[Authorize]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<DepartmentDto>>> GetAllDepartments()
        {
            var departments = await _departmentService.GetAllDepartments();
            return Ok(departments);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Result<DepartmentDto>>> GetDepartmentById(int id)
        {
            var department = await _departmentService.GetDepartmentById(new GetDepartmentByIdVM { Id = id });
            return Ok(department);
        }

        

        [HttpPost("create")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<Result<int>>> CreateDepartment(CreateDepartmentVM createDepartmentVM)
        {
            var departmentId = await _departmentService.CreateDepartment(createDepartmentVM);
            return Ok(departmentId);
        }

        [HttpDelete("delete")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<Result<int>>> DeleteDepartment(DeleteDepartmentVM deleteDepartmentVM)
        {
            var departmentId = await _departmentService.DeleteDepartment(deleteDepartmentVM);
            return Ok(departmentId);
        }

        [HttpPost("update/{id:int}")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<Result<int>>> UpdateDepartment(int id, UpdateDepartmentVM updateDepartmentVM)
        {
            if (id != updateDepartmentVM.Id)
            {
                return BadRequest();
            }

            var departmentId = await _departmentService.UpdateDepartment(updateDepartmentVM);
            return Ok(departmentId);
        }
    }
}
