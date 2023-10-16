using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SASSTS.Application.Behaviors;
using SASSTS.Application.Exceptions;
using SASSTS.Application.Models.Dtos.PriceOfferDtos;
using SASSTS.Application.Models.RequestModels.PriceOffersRM;
using SASSTS.Application.Services.Abstraction;
using SASSTS.Application.Validators.PriceOfferValidators;
using SASSTS.Application.Wrapper;
using SASSTS.Domain.Entities;
using SASSTS.Domain.UWork;

namespace SASSTS.Application.Services.Implementation
{
    public class PriceOfferService : IPriceOfferService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public PriceOfferService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        public async Task<Result<List<PriceOfferDto>>> GetAllPriceOffers()
        {
            var result = new Result<List<PriceOfferDto>>();


            var priceOfferEntites = await _unitWork.GetRepository<PriceOffer>().GetAllAsync();
            var priceOfferDtos = await priceOfferEntites.ProjectTo<PriceOfferDto>(_mapper.ConfigurationProvider).ToListAsync();
            result.Data = priceOfferDtos;
            _unitWork.Dispose();

            return result;
        }

        [ValidationBehavior(typeof(GetPriceOfferByIdValidator))]
        public async Task<Result<PriceOfferDto>> GetPriceOfferById(GetPriceOfferByIdVM getPriceOfferByIdVM)
        {
            var result = new Result<PriceOfferDto>();

            var priceOfferExists = await _unitWork.GetRepository<PriceOffer>().AnyAsync(x => x.Id == getPriceOfferByIdVM.Id);
            if (!priceOfferExists)
            {
                throw new NotFoundException($"{getPriceOfferByIdVM.Id} numaralı teklif bulunamadı.");
            }

            var priceOfferEntity = await _unitWork.GetRepository<PriceOffer>().GetById(getPriceOfferByIdVM.Id);

            var priceOfferDto = _mapper.Map<PriceOffer, PriceOfferDto>(priceOfferEntity);

            result.Data = priceOfferDto;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(CreatePriceOfferValidator))]
        public async Task<Result<int>> CreatePriceOffer(CreatePriceOfferVM createPriceOfferVM)
        {
            var result = new Result<int>();

            var customerExistsSame = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.Name + ' ' + x.Surname == createPriceOfferVM.CustomerName && x.Id == createPriceOfferVM.CustomerId);
            if (!customerExistsSame)
            {
                throw new NotFoundException($"Girilen personel bilgileri eşleşmiyor veya kayıtlı değil.");
            }

            var wholesalerExistsSame = await _unitWork.GetRepository<Wholesaler>().AnyAsync(x => x.WholesalerName == createPriceOfferVM.WholesalerName && x.Id == createPriceOfferVM.WholesalerId);
            if (!wholesalerExistsSame)
            {
                throw new NotFoundException($"Girilen tedarikçi bilgileri eşleşmiyor veya kayıtlı değil.");
            }

            var productExistsSame = await _unitWork.GetRepository<Product>().AnyAsync(x => x.ProductName == createPriceOfferVM.ProductName && x.Id == createPriceOfferVM.ProductId);
            if (!productExistsSame)
            {
                throw new NotFoundException($"Girilen personel bilgileri eşleşmiyor veya kayıtlı değil.");
            }

            var priceOfferEntity = _mapper.Map<CreatePriceOfferVM, PriceOffer>(createPriceOfferVM);

            _unitWork.GetRepository<PriceOffer>().Add(priceOfferEntity);
            await _unitWork.CommitAsync();

            result.Data = priceOfferEntity.Id;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(DeletePriceOfferValidator))]
        public async Task<Result<int>> DeletePriceOffer(DeletePriceOfferVM deletePriceOfferVM)
        {
            var result = new Result<int>();

            var priceOfferExists = await _unitWork.GetRepository<PriceOffer>().AnyAsync(x => x.Id == deletePriceOfferVM.Id);
            if (!priceOfferExists)
            {
                throw new NotFoundException($"{deletePriceOfferVM.Id} numaralı teklif bulunamadı.");
            }

            _unitWork.GetRepository<PriceOffer>().Delete(deletePriceOfferVM.Id);
            await _unitWork.CommitAsync();

            result.Data = deletePriceOfferVM.Id;
            _unitWork.Dispose();
            return result;
        }


        [ValidationBehavior(typeof(UpdatePriceOfferValidator))]
        public async Task<Result<int>> UpdatePriceOffer(UpdatePriceOfferVM updatePriceOfferVM)
        {
            var result = new Result<int>();

            var existsPriceOffer = await _unitWork.GetRepository<PriceOffer>().GetById(updatePriceOfferVM.Id);
            if (existsPriceOffer is null)
            {
                throw new NotFoundException($"{updatePriceOfferVM} numaralı teklif bulunamadı.");
            }

            var customerExistsSame = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.Name + ' ' + x.Surname == updatePriceOfferVM.CustomerName && x.Id == updatePriceOfferVM.CustomerId);
            if (!customerExistsSame)
            {
                throw new NotFoundException($"Girilen personel bilgileri eşleşmiyor veya kayıtlı değil.");
            }

            var wholesalerExistsSame = await _unitWork.GetRepository<Wholesaler>().AnyAsync(x => x.WholesalerName == updatePriceOfferVM.WholesalerName && x.Id == updatePriceOfferVM.WholesalerId);
            if (!wholesalerExistsSame)
            {
                throw new NotFoundException($"Girilen tedarikçi bilgileri eşleşmiyor veya kayıtlı değil.");
            }

            var productExistsSame = await _unitWork.GetRepository<Product>().AnyAsync(x => x.ProductName == updatePriceOfferVM.ProductName && x.Id == updatePriceOfferVM.ProductId);
            if (!productExistsSame)
            {
                throw new NotFoundException($"Girilen personel bilgileri eşleşmiyor veya kayıtlı değil.");
            }

            var updatedPriceOffer = _mapper.Map(updatePriceOfferVM, existsPriceOffer);

            _unitWork.GetRepository<PriceOffer>().Update(updatedPriceOffer);
            await _unitWork.CommitAsync();

            result.Data = updatedPriceOffer.Id;
            _unitWork.Dispose();
            return result;
        }
    }
}
