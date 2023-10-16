using Microsoft.AspNetCore.Mvc;
using SASSTS.Application.Models.Dtos.ProductDtos;
using SASSTS.Application.Models.Dtos.PurchaseRequestDtos;
using SASSTS.Application.Models.RequestModels.PurchaseRequestsRM;
using SASSTS.Application.Services.Abstraction;
using SASSTS.Application.Wrapper;

namespace SASSTS.Api.Controllers
{
    [Route("purchaseRequest")]
    [ApiController]
    //[Authorize]
    public class PurchaseRequestsController : ControllerBase
    {
        private readonly IPurchaseRequestService _purchaseRequestService;


        public PurchaseRequestsController(IPurchaseRequestService purchaseRequestService)
        {
            _purchaseRequestService = purchaseRequestService;
        }

        [HttpGet("get")]
        //[Authorize(Roles = "User,ProductManager,DepartmentManager,CompanyManager")]
        public async Task<ActionResult<List<PurchaseRequestDto>>> GetAllPurchaseRequests()
        {
            var purchaseRequests = await _purchaseRequestService.GetAllPurchaseRequests();
            return Ok(purchaseRequests);
        }

        [HttpGet("get/{id:int}")]
        //[Authorize(Roles = "User,ProductManager,DepartmentManager,CompanyManager")]
        public async Task<ActionResult<Result<ProductDto>>> GetProductById(int id)
        {
            var purchaseRequest = await _purchaseRequestService.GetPurchaseRequestById(new GetPurchaseRequestByIdVM { Id = id });
            
            return Ok(purchaseRequest);
        }

        [HttpPost("create")]
        //[Authorize(Roles = "User")]
        public async Task<ActionResult<Result<int>>> CreatePurchaseRequest(CreatePurchaseRequestVM createPurchaseRequestVM)
        {
            var purchaseRequestId = await _purchaseRequestService.CreatePurchaseRequest(createPurchaseRequestVM);
            
            return Ok(purchaseRequestId);
        }

        [HttpDelete("delete")]
        //[Authorize(Roles = "User")]
        public async Task<ActionResult<Result<int>>> DeletePurchaseRequest(DeletePurchaseRequestVM deletePurchaseRequestVM)
        {
            var purchaseRequestId = await _purchaseRequestService.DeletePurchaseRequest(deletePurchaseRequestVM);
            return Ok(purchaseRequestId);
        }

        [HttpPost("update/{id:int}")]
        //[Authorize(Roles = "User,ProductManager")]
        public async Task<ActionResult<Result<int>>> UpdatePurchaseRequest(int id, UpdatePurchaseRequestVM updatePurchaseRequestVM)
        {
            if (id != updatePurchaseRequestVM.Id)
            {
                return BadRequest();
            }

            var purchaseRequestId = await _purchaseRequestService.UpdatePurchaseRequest(updatePurchaseRequestVM);
            return Ok(purchaseRequestId);
        }
    }
}
