using Microsoft.AspNetCore.Mvc;
using SASSTS.Application.Models.Dtos.BillsDtos;
using SASSTS.Application.Models.RequestModels.BillsRM;
using SASSTS.Application.Services.Abstraction;
using SASSTS.Application.Wrapper;

namespace SASSTS.Api.Controllers
{
    [Route("bill")]
    [ApiController]
    //[Authorize]
    public class BillsController : ControllerBase
    {
        private readonly IBillService _billService;

        public BillsController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpGet("get")]
        //[Authorize(Roles = "Accounting, DepartmentManager, CompanyManager")]
        public async Task<ActionResult<List<BillDto>>> GetAllBills()
        {
            var bills = await _billService.GetAllBills();
            return Ok(bills);
        }

        [HttpGet("get/{id:int}")]
        //[Authorize(Roles = "Accounting, DepartmentManager, CompanyManager")]
        public async Task<ActionResult<Result<BillDto>>> GetBillById(int id)
        {
            var bill = await _billService.GetBillById(new GetBillByIdVM { Id = id });
            return Ok(bill);
        }

        [HttpPost("create")]
        //[Authorize(Roles = "Accounting")]
        public async Task<ActionResult<Result<int>>> CreateBill(CreateBillVM createBillVM)
        {
            var billId = await _billService.CreateBill(createBillVM);
            return Ok(billId);
        }

        [HttpPost("update/{id:int}")]
        //[Authorize(Roles = "Accounting")]
        public async Task<ActionResult<Result<int>>> UpdateBill(int id,UpdateBillVM updateBillVM)
        {
            if (id != updateBillVM.Id)
            {
                return BadRequest();
            }

            var billId = await _billService.UpdateBill(updateBillVM);
            return Ok(billId);
        }
    }
}
