using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SASSTS.Application.Models.Dtos.CustomerDtos;
using SASSTS.Application.Models.RequestModels.CategoriesRM;
using SASSTS.Application.Models.RequestModels.CustomerRM;
using SASSTS.Application.Services.Abstraction;
using SASSTS.Application.Services.Implementation;
using SASSTS.Application.Wrapper;
using SASSTS.Domain.Entities;

namespace SASSTS.Api.Controllers
{
    [Route("customer")]
    [ApiController]
    //[Authorize]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("get")]
        //[Authorize(Roles = "Accounting,DepartmentManager, CompanyManager,Admin")]
        public async Task<ActionResult<List<CustomerDto>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("get/{id:int}")]
        //[Authorize(Roles = "Accounting,DepartmentManager, CompanyManager,Admin")]
        public async Task<ActionResult<Result<CustomerDto>>> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerById(new GetCustomerByIdVM { Id = id });
            return Ok(customer);
        }

        //[HttpGet("get/{NameSurname}")]
        //public async Task<ActionResult<Result<CustomerDto>>> GetCustomerByName(string nameSurname,GetCustomerByNameVM getCustomerByNameVM)
        //{
        //    var customerName = getCustomerByNameVM.Name + ' ' + getCustomerByNameVM.Surname;
        //    var customer = await _customerService.GetCustomerByName(new customerName=nameSurname);
        //    return Ok(customer);
        //}


        [HttpDelete("delete/{id:int}")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<Result<int>>> DeleteCustomer(int id)
        {
            var customerId = await _customerService.DeleteCustomer(new DeleteCustomerVM { Id = id });
            return Ok(customerId);
        }


        [HttpPost("update/{id:int}")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<Result<int>>> UpdateCustomer(int id, UpdateCustomerVM updateCustomerVM)
        {
            if (id != updateCustomerVM.Id)
            {
                return BadRequest();
            }

            var customerId = await _customerService.UpdateCustomer(updateCustomerVM);
            return Ok(customerId);
        }
    }

    
}
