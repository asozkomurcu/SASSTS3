using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SASSTS.Application.Models.Dtos.WholesalerDtos;
using SASSTS.Application.Models.RequestModels.WholesalersRM;
using SASSTS.Application.Services.Abstraction;
using SASSTS.Application.Wrapper;
using SASSTS.Domain.Entities;

namespace SASSTS.Api.Controllers
{
    [Route("wholesaler")]
    [ApiController]
    //[Authorize]
    public class WholesalersController : ControllerBase
    {
        private readonly IWholesalerService _wholesalerService;

        public WholesalersController(IWholesalerService wholesalerService)
        {
            _wholesalerService = wholesalerService;
        }

        [HttpGet("get")]
        //[Authorize(Roles = "Accounting,ProductManager,DepartmentManager,CompanyManager")]
        public async Task<ActionResult<List<WholesalerDto>>> GetAllWholesalers()
        {
            var wholesalers = await _wholesalerService.GetAllWholesaler();
            return Ok(wholesalers);
        }

        [HttpGet("get/{id:int}")]
        //[Authorize(Roles = "Accounting,ProductManager,DepartmentManager,CompanyManager")]
        public async Task<ActionResult<Result<WholesalerDto>>> GetWholesalerById(int id)
        {
            var wholesaler = await _wholesalerService.GetWholesalerById(new GetWholesalerByIdVM { Id = id });
            return Ok(wholesaler);
        }

        [HttpPost("create")]
        //[Authorize(Roles = "ProductManager")]
        public async Task<ActionResult<Result<int>>> CreateWholesaler(CreateWholesalerVM createWholesalerVM)
        {
            var wholesalerId = await _wholesalerService.CreateWholesaler(createWholesalerVM);
            return Ok(wholesalerId);
        }

        [HttpDelete("delete")]
        //[Authorize(Roles = "ProductManager")]
        public async Task<ActionResult<Result<int>>> DeleteWholesaler(DeleteWholesalerVM deleteWholesalerVM)
        {
            var wholesalerId = await _wholesalerService.DeleteWholesaler(deleteWholesalerVM);
            return Ok(wholesalerId);
        }

        [HttpPost("update/{id:int}")]
        //[Authorize(Roles = "ProductManager")]
        public async Task<ActionResult<Result<int>>> UpdateWholesaler(int id, UpdateWholesalerVM updateWholesalerVM)
        {
            if (id != updateWholesalerVM.Id)
            {
                return BadRequest();
            }

            var wholesalerId = await _wholesalerService.UpdateWholesaler(updateWholesalerVM);
            return Ok(wholesalerId);
        }
    }
}
