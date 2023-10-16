using SASSTS.Application.Models.Dtos.PriceOfferDtos;
using SASSTS.Application.Models.RequestModels.PriceOffersRM;
using SASSTS.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Services.Abstraction
{
    public interface IPriceOfferService
    {
        Task<Result<List<PriceOfferDto>>> GetAllPriceOffers();
        Task<Result<PriceOfferDto>> GetPriceOfferById(GetPriceOfferByIdVM getPriceOfferByIdVM);
        Task<Result<int>> CreatePriceOffer(CreatePriceOfferVM createPriceOfferVM);
        Task<Result<int>> UpdatePriceOffer(UpdatePriceOfferVM updatePriceOfferVM);
        Task<Result<int>> DeletePriceOffer(DeletePriceOfferVM deletePriceOfferVM);
    }
}
