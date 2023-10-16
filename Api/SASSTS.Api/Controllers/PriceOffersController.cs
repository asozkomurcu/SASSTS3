using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SASSTS.Application.Models.Dtos.PriceOfferDtos;
using SASSTS.Application.Models.RequestModels.PriceOffersRM;
using SASSTS.Application.Services.Abstraction;
using SASSTS.Application.Wrapper;

namespace SASSTS.Api.Controllers
{
    [Route("priceOffers")]
    [ApiController]
    //[Authorize]
    public class PriceOffersController : ControllerBase
    {
        private readonly IPriceOfferService _priceOfferService;

        public PriceOffersController(IPriceOfferService priceOfferService)
        {
            _priceOfferService = priceOfferService;
        }

        [HttpGet("get")]
        //[Authorize(Roles = "ProductManager,DepartmentManager,CompanyManager")]
        public async Task<ActionResult<List<PriceOfferDto>>> GetAllPriceOffers()
        {
            var priceOffers = await _priceOfferService.GetAllPriceOffers();
            return Ok(priceOffers);
        }

        [HttpGet("get/{id:int}")]
        //[Authorize(Roles = "ProductManager,DepartmentManager,CompanyManager")]
        public async Task<ActionResult<Result<PriceOfferDto>>> GetPriceOfferById(int id)
        {
            var priceOffer = await _priceOfferService.GetPriceOfferById(new GetPriceOfferByIdVM { Id = id });
            return Ok(priceOffer);
        }

        [HttpDelete("delete")]
        //[Authorize(Roles = "ProductManager")]
        public async Task<ActionResult<Result<int>>> DeletePriceOffer(DeletePriceOfferVM deletePriceOfferVM)
        {
            var PriceOfferId = await _priceOfferService.DeletePriceOffer(deletePriceOfferVM);
            return Ok(PriceOfferId);
        }

        [HttpPost("create")]
        //[Authorize(Roles = "ProductManager")]
        public async Task<ActionResult<Result<int>>> CreatePriceOffer(CreatePriceOfferVM createPriceOfferVM)
        {
            var priceOfferId = await _priceOfferService.CreatePriceOffer(createPriceOfferVM);
            return Ok(priceOfferId);
        }

        [HttpPost("update/{id:int}")]
        //[Authorize(Roles = "ProductManager")]
        public async Task<ActionResult<Result<int>>> UpdatePriceOffer(int id, UpdatePriceOfferVM updatePriceOfferVM)
        {
            if (id != updatePriceOfferVM.Id)
            {
                return BadRequest();
            }

            var priceOfferId = await _priceOfferService.UpdatePriceOffer(updatePriceOfferVM);
            return Ok(priceOfferId);
        }
    }
}
