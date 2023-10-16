using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SASSTS.Application.Behaviors;
using SASSTS.Application.Exceptions;
using SASSTS.Application.Models.Dtos.PurchasedProductDtos;
using SASSTS.Application.Models.RequestModels.PurchasedProductsRM;
using SASSTS.Application.Models.RequestModels.PurchaseRequestsRM;
using SASSTS.Application.Services.Abstraction;
using SASSTS.Application.Validators.PurchasedProductValidators;
using SASSTS.Application.Wrapper;
using SASSTS.Domain.Entities;
using SASSTS.Domain.UWork;
using SASSTS.Domain.Entities;

namespace SASSTS.Application.Services.Implementation
{
    public class PurchasedProductService : IPurchasedProductService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;


        public PurchasedProductService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        public async Task<Result<List<PurchasedProductDto>>> GetAllPurchasedProduct()
        {
            var result = new Result<List<PurchasedProductDto>>();

            var purchasedProductEntites = await _unitWork.GetRepository<PurchasedProduct>().GetAllAsync();
            var purchasedProductDtos = await purchasedProductEntites.ProjectTo<PurchasedProductDto>(_mapper.ConfigurationProvider).ToListAsync();
            result.Data = purchasedProductDtos;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(GetPurchasedProductByIdValidator))]
        public async Task<Result<PurchasedProductDto>> GetPurchasedProductById(GetPurchasedProductByIdVM getPurchasedProductByIdVM)
        {
            var result = new Result<PurchasedProductDto>();

            var purchasedProductExists = await _unitWork.GetRepository<PurchasedProduct>().AnyAsync(x => x.Id == getPurchasedProductByIdVM.Id);
            if (!purchasedProductExists)
            {
                throw new NotFoundException($"{getPurchasedProductByIdVM.Id} numaralı ürün bulunamadı.");
            }

            var purchasedProductEntity = await _unitWork.GetRepository<PurchasedProduct>().GetById(getPurchasedProductByIdVM.Id);

            var purchasedProductDto = _mapper.Map<PurchasedProduct, PurchasedProductDto>(purchasedProductEntity);

            result.Data = purchasedProductDto;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(CreatePurchasedProductValidator))]
        public async Task<Result<int>> CreatePurchasedProduct(CreatePurchasedProductVM createPurchasedProductVM)
        {
            var result = new Result<int>();
            var customerRole = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.UserAuthorizations == UserAuthorizations.OfferRecipient);
            if (customerRole)
            {
                var customerExistsSame = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.Name + ' ' + x.Surname == createPurchasedProductVM.CustomerName && x.Id == createPurchasedProductVM.CustomerId);
                if (!customerExistsSame)
                {
                    throw new NotFoundException($"Girilen personel bilgileri eşleşmiyor veya kayıtlı değil.");
                }

                var wholesalerExistsSame = await _unitWork.GetRepository<Wholesaler>().AnyAsync(x => x.WholesalerName == createPurchasedProductVM.WholesalerName && x.Id == createPurchasedProductVM.WholesalerId);
                if (!wholesalerExistsSame)
                {
                    throw new NotFoundException($"Girilen tedarikçi bilgileri eşleşmiyor veya kayıtlı değil.");
                }

                var productExistsSame = await _unitWork.GetRepository<Product>().AnyAsync(x => x.ProductName == createPurchasedProductVM.ProductName && x.Id == createPurchasedProductVM.ProductId);
                if (!productExistsSame)
                {
                    throw new NotFoundException($"Girilen ürün bilgileri eşleşmiyor veya kayıtlı değil.");
                }



                var purchasedProductEntity = _mapper.Map<CreatePurchasedProductVM, PurchasedProduct>(createPurchasedProductVM);
                _unitWork.GetRepository<PurchasedProduct>().Add(purchasedProductEntity);
                await _unitWork.CommitAsync();

                result.Data = purchasedProductEntity.Id;
            }
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(UpdatePurchasedProductValidator))]
        public async Task<Result<int>> UpdatePurchasedProduct(UpdatePurchasedProductVM updatePurchasedProductVM)
        {
            var result = new Result<int>();

            var existsPurchasedProduct = await _unitWork.GetRepository<PurchasedProduct>().GetById(updatePurchasedProductVM.Id);
            if (existsPurchasedProduct is null)
            {
                throw new NotFoundException($"{updatePurchasedProductVM} numaralı satın alınan ürün listesi bulunamadı.");
            }

            var customerExistsSame = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.Name + ' ' + x.Surname == updatePurchasedProductVM.CustomerName && x.Id == updatePurchasedProductVM.CustomerId);
            if (!customerExistsSame)
            {
                throw new NotFoundException($"Girilen personel bilgileri eşleşmiyor veya kayıtlı değil.");
            }

            var wholesalerExistsSame = await _unitWork.GetRepository<Wholesaler>().AnyAsync(x => x.WholesalerName == updatePurchasedProductVM.WholesalerName && x.Id == updatePurchasedProductVM.WholesalerId);
            if (!wholesalerExistsSame)
            {
                throw new NotFoundException($"Girilen tedarikçi bilgileri eşleşmiyor veya kayıtlı değil.");
            }

            var productExistsSame = await _unitWork.GetRepository<Product>().AnyAsync(x => x.ProductName == updatePurchasedProductVM.ProductName && x.Id == updatePurchasedProductVM.ProductId);
            if (!productExistsSame)
            {
                throw new NotFoundException($"Girilen ürün bilgileri eşleşmiyor veya kayıtlı değil.");
            }



            var updatedPurchasedProduct = _mapper.Map(updatePurchasedProductVM, existsPurchasedProduct);

            _unitWork.GetRepository<PurchasedProduct>().Update(updatedPurchasedProduct);
            await _unitWork.CommitAsync();

            result.Data = updatedPurchasedProduct.Id;
            _unitWork.Dispose();
            return result;
        }

    }
}
