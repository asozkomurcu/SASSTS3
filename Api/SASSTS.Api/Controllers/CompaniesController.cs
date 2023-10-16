using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SASSTS.Application.Models.Dtos.CompanyDtos;
using SASSTS.Application.Models.RequestModels.CompaniesRM;
using SASSTS.Application.Services.Abstraction;
using SASSTS.Application.Wrapper;
using SASSTS.Domain.Entities;

namespace SASSTS.Api.Controllers
{
    [Route("company")]
    [ApiController]
    //[Authorize]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("get")]
        //[AllowAnonymous]
        public async Task<ActionResult<List<CompanyDto>>> GetAllCompanies()
        {
            var companies = await _companyService.GetAllCompanies();
            return Ok(companies);
        }

        [HttpGet("get/{id:int}")]
        //[AllowAnonymous]
        public async Task<ActionResult<Result<CompanyDto>>> GetCompanyById(int id)
        {
            var company = await _companyService.GetCompanyById(new GetCompanyByIdVM { Id = id });
            return Ok(company);
        }

        [HttpPost("create")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<Result<int>>> CreateCompany(CreateCompanyVM createCompanyVM)
        {
            var companyId = await _companyService.CreateCompany(createCompanyVM);
            return Ok(companyId);
        }

        [HttpDelete("delete")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<Result<int>>> DeleteCompany(DeleteCompanyVM deleteCompanyVM)
        {
            var companyId = await _companyService.DeleteCompany( deleteCompanyVM);
            return Ok(companyId);
        }

        [HttpPost("update/{id:int}")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<Result<int>>> UpdateCompany(int id, UpdateCompanyVM updateCompanyVM)
        {
            if (id != updateCompanyVM.Id)
            {
                return BadRequest();
            }

            var companyId = await _companyService.UpdateCompany(updateCompanyVM);
            return Ok(companyId);
        }
    }
}
