using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SASSTS.Application.Behaviors;
using SASSTS.Application.Exceptions;
using SASSTS.Application.Models.Dtos.PurchaseRequestDtos;
using SASSTS.Application.Models.RequestModels.PurchaseRequestsRM;
using SASSTS.Application.Services.Abstraction;
using SASSTS.Application.Validators.PurchaseRequestValidators;
using SASSTS.Application.Wrapper;
using SASSTS.Domain.Entities;
using SASSTS.Domain.UWork;
using SASSTS.Domain.Entities;

namespace SASSTS.Application.Services.Implementation
{
    public class PurchaseRequestService : IPurchaseRequestService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;
        private readonly IMailService _mailService;
        private readonly IMessageService _messageService;


        public PurchaseRequestService(IMapper mapper, IUnitWork unitWork, IMailService mailService, IMessageService messageService)
        {
            _mapper = mapper;
            _unitWork = unitWork;
            _mailService = mailService;
            _messageService = messageService;
        }


        public async Task<Result<List<PurchaseRequestDto>>> GetAllPurchaseRequests()
        {
            var result = new Result<List<PurchaseRequestDto>>();

            var purchaseRequestEntites = await _unitWork.GetRepository<PurchaseRequest>().GetAllAsync();
            var purchaseRequestDtos = await purchaseRequestEntites.ProjectTo<PurchaseRequestDto>(_mapper.ConfigurationProvider).ToListAsync();
            result.Data = purchaseRequestDtos;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(GetPurchaseRequestByIdValidator))]
        public async Task<Result<PurchaseRequestDto>> GetPurchaseRequestById(GetPurchaseRequestByIdVM getPurchaseRequestByIdVM)
        {
            var result = new Result<PurchaseRequestDto>();

            var purchaseRequestExists = await _unitWork.GetRepository<PurchaseRequest>().AnyAsync(x => x.Id == getPurchaseRequestByIdVM.Id);
            if (!purchaseRequestExists)
            {
                throw new NotFoundException($"{getPurchaseRequestByIdVM.Id} numaralı ürün bulunamadı.");
            }

            var purchaseRequestEntity = await _unitWork.GetRepository<PurchaseRequest>().GetById(getPurchaseRequestByIdVM.Id);

            var purchaseRequestDto = _mapper.Map<PurchaseRequest, PurchaseRequestDto>(purchaseRequestEntity);

            result.Data = purchaseRequestDto;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(CreatePurchaseRequestValidator))]
        public async Task<Result<int>> CreatePurchaseRequest(CreatePurchaseRequestVM createPurchaseRequestVM)
        {
            var result = new Result<int>();
            var customerRoleOffer = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.UserAuthorizations == UserAuthorizations.RequestPerson);
            if (customerRoleOffer)
            {
                var customerExistsSame = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.Name + ' ' + x.Surname == createPurchaseRequestVM.RequestCustomerName && x.Id == createPurchaseRequestVM.RequestCustomerId);
                if (!customerExistsSame)
                {
                    throw new NotFoundException($"Girilen personel bilgileri eşleşmiyor veya kayıtlı değil.");
                }


                var purchaseRequestEntity = _mapper.Map<CreatePurchaseRequestVM, PurchaseRequest>(createPurchaseRequestVM);

                _unitWork.GetRepository<PurchaseRequest>().Add(purchaseRequestEntity);
                await _unitWork.CommitAsync();

                result.Data = purchaseRequestEntity.Id;
            }
            var customer = await _unitWork.GetRepository<Customer>().GetSingleByFilterAsync(x => x.UserAuthorizations == UserAuthorizations.OfferRecipient);
            var customerEmail = customer.Email;
            await _mailService.SendMessageAsync($"{customerEmail}", _messageService.SubjectPurchaseRequestMessage(), _messageService.RegisterMessage(createPurchaseRequestVM));
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(DeletePurchaseRequestValidator))]
        public async Task<Result<int>> DeletePurchaseRequest(DeletePurchaseRequestVM deletePurchaseRequestVM)
        {
            var result = new Result<int>();
            var customerRole = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.UserAuthorizations == UserAuthorizations.RequestPerson);
            if (customerRole)
            {
                var purchaseRequestExists = await _unitWork.GetRepository<PurchaseRequest>().AnyAsync(x => x.Id == deletePurchaseRequestVM.Id);
                if (!purchaseRequestExists)
                {
                    throw new NotFoundException($"{deletePurchaseRequestVM.Id} numaralı Satın alım talebi bulunamadı.");
                }

                _unitWork.GetRepository<PurchaseRequest>().Delete(deletePurchaseRequestVM.Id);
                await _unitWork.CommitAsync();

                result.Data = deletePurchaseRequestVM.Id;
            }
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(UpdatePurchaseRequestValidator))]
        public async Task<Result<int>> UpdatePurchaseRequest(UpdatePurchaseRequestVM updatePurchaseRequestVM)
        {
            var result = new Result<int>();

            var existsPurchaseRequest = await _unitWork.GetRepository<PurchaseRequest>().GetById(updatePurchaseRequestVM.Id);
            if (existsPurchaseRequest is null)
            {
                throw new NotFoundException($"{updatePurchaseRequestVM} numaralı satın alım talebi bulunamadı.");
            }

            //var customerExistsSame = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.Name + ' ' + x.Surname == updatePurchaseRequestVM.RequestCustomerName && x.Id == updatePurchaseRequestVM.RequestCustomerId);
            //if (!customerExistsSame)
            //{
            //    throw new NotFoundException($"Girilen personel bilgileri eşleşmiyor veya kayıtlı değil.");
            //}

            var customerRoleOffer = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.UserAuthorizations == UserAuthorizations.OfferRecipient);
            if (customerRoleOffer)
            {
                //updatePurchaseRequestVM.Status = Status.Waiting;

                var updatedPurchaseRequest = _mapper.Map(updatePurchaseRequestVM, existsPurchaseRequest);

                _unitWork.GetRepository<PurchaseRequest>().Update(updatedPurchaseRequest);
                await _unitWork.CommitAsync();

                result.Data = updatedPurchaseRequest.Id;
            }

            var purchaseRequestEntity = await _unitWork.GetRepository<PurchaseRequest>().GetById(updatePurchaseRequestVM.Id);
            double totalprice = ((double)purchaseRequestEntity.PriceOffer.TotalPrice);
            if (totalprice < 100000)
            {
                var customer = await _unitWork.GetRepository<Customer>().GetSingleByFilterAsync(x => x.UserAuthorizations == UserAuthorizations.MinApprove);
                var email = customer.Email;
                await _mailService.SendMessageAsync($"{email}", _messageService.SubjectPurchaseRequestMessage(), _messageService.RegisterMessage(updatePurchaseRequestVM));
            }
            else
            {
                var customer = await _unitWork.GetRepository<Customer>().GetSingleByFilterAsync(x => x.UserAuthorizations == UserAuthorizations.MaxApprove);
                var email = customer.Email;
                var nameSurname = customer.Name + ' ' + customer.Surname;
                await _mailService.SendMessageAsync($"{email}", _messageService.SubjectPurchaseRequestMessage(), $"Sayın {nameSurname}. Bir adet satın alım talebi onayınızı bekliyor.");
            }



            _unitWork.Dispose();
            return result;

        }
    }
}
