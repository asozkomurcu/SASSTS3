using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SASSTS.Application.Models.Dtos.PurchasedProductDtos;
using SASSTS.Application.Models.RequestModels.PurchasedProductsRM;
using SASSTS.Application.Services.Abstraction;
using SASSTS.Application.Wrapper;

namespace SASSTS.Api.Controllers
{
    [Route("purchasedProduct")]
    [ApiController]
    //[Authorize]
    public class PurchasedProductsController : ControllerBase
    {
        private readonly IPurchasedProductService _purchasedProductService;
        private readonly IMessageService _messageService;
        private readonly IMailService _mailService;

        public PurchasedProductsController(IPurchasedProductService purchasedProductService, IMessageService messageService, IMailService mailService)
        {
            _purchasedProductService = purchasedProductService;
            _messageService = messageService;
            _mailService = mailService;
        }

        [HttpGet("get")]
        //[Authorize(Roles = "Accounting,ProductManager,DepartmentManager,CompanyManager")]
        public async Task<ActionResult<List<PurchasedProductDto>>> GetAllPurchasedProduct()
        {
            var purchasedProducts = await _purchasedProductService.GetAllPurchasedProduct();
            return Ok(purchasedProducts);
        }

        [HttpGet("get/id:int")]
        //[Authorize(Roles = "Accounting,ProductManager,DepartmentManager,CompanyManager")]
        public async Task<ActionResult<Result<PurchasedProductDto>>> GetPurchasedProductById(int id)
        {
            var purchasedProduct = await _purchasedProductService.GetPurchasedProductById(new GetPurchasedProductByIdVM { Id = id });
            return Ok(purchasedProduct);
        }

        [HttpPost("create")]
        //[Authorize(Roles = "ProductManager")]
        public async Task<ActionResult<Result<int>>> CreatePurchasedProduct(CreatePurchasedProductVM createpurchasedProductVM)
        {
            var purchasedProductId = await _purchasedProductService.CreatePurchasedProduct(createpurchasedProductVM);
            //await _mailService.SendMessageAsync($"{}")
            //    ($"{createUserVM.Email}", _messageService.SubjectMessage(), _messageService.RegisterMessage(createUserVM
            return Ok(purchasedProductId);
        }

        [HttpPost("update")]
        //[Authorize(Roles = "ProductManager")]
        public async Task<ActionResult<Result<int>>> UpdatePurchasedProduct(UpdatePurchasedProductVM updatepurchasedProductVM)
        {
            var purchasedProductId = await _purchasedProductService.UpdatePurchasedProduct(updatepurchasedProductVM);
            return Ok(purchasedProductId);
        }
    }
}
