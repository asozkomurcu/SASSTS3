using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SASSTS.Application.Behaviors;
using SASSTS.Application.Exceptions;
using SASSTS.Application.Models.Dtos.WholesalerDtos;
using SASSTS.Application.Models.RequestModels.WholesalersRM;
using SASSTS.Application.Services.Abstraction;
using SASSTS.Application.Validators.WholesalerValidators;
using SASSTS.Application.Wrapper;
using SASSTS.Domain.Entities;
using SASSTS.Domain.UWork;

namespace SASSTS.Application.Services.Implementation
{
    public class WholesalerService : IWholesalerService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public WholesalerService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        public async Task<Result<List<WholesalerDto>>> GetAllWholesaler()
        {
            var result = new Result<List<WholesalerDto>>();

            var wholesalerEntites = await _unitWork.GetRepository<Wholesaler>().GetAllAsync();
            var wholesalerDtos = await wholesalerEntites.ProjectTo<WholesalerDto>(_mapper.ConfigurationProvider).ToListAsync();
            result.Data = wholesalerDtos;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(GetWholesalerByIdValidator))]
        public async Task<Result<WholesalerDto>> GetWholesalerById(GetWholesalerByIdVM getWholesalerByIdVM)
        {
            var result = new Result<WholesalerDto>();

            var wholesalerExists = await _unitWork.GetRepository<Wholesaler>().AnyAsync(x => x.Id == getWholesalerByIdVM.Id);
            if (!wholesalerExists)
            {
                throw new NotFoundException($"{getWholesalerByIdVM.Id} numaralı tedarikçi bulunamadı.");
            }

            var wholesalerEntity = await _unitWork.GetRepository<Wholesaler>().GetById(getWholesalerByIdVM.Id);

            var wholesalerDto = _mapper.Map<Wholesaler, WholesalerDto>(wholesalerEntity);

            result.Data = wholesalerDto;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(CreateWholesalerValidator))]
        public async Task<Result<int>> CreateWholesaler(CreateWholesalerVM createWholesalerVM)
        {
            var result = new Result<int>();

            var wholesalerExistsSameName = await _unitWork.GetRepository<Wholesaler>().AnyAsync(x => x.WholesalerName == createWholesalerVM.WholesalerName);
            if (wholesalerExistsSameName)
            {
                throw new AlreadyExistsException($"{createWholesalerVM.WholesalerName} isminde bir tedarikçi zaten mevcut.");
            }

            var phoneCustomerExists = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.Phone == createWholesalerVM.Phone);
            if (phoneCustomerExists)
            {
                throw new AlreadyExistsException($"Girmiş olduğunuz telefon numarası kayıtlı. Lütfen numaranızı kontrol ederek tekrar giriniz.");
            }

            var phoneWholesalerExists = await _unitWork.GetRepository<Wholesaler>().AnyAsync(x => x.Phone == createWholesalerVM.Phone);
            if (phoneWholesalerExists)
            {
                throw new AlreadyExistsException($"Girmiş olduğunuz telefon numarası kayıtlı. Lütfen numaranızı kontrol ederek tekrar giriniz.");
            }

            var wholesalerEntity = _mapper.Map<CreateWholesalerVM, Wholesaler>(createWholesalerVM);

            _unitWork.GetRepository<Wholesaler>().Add(wholesalerEntity);
            await _unitWork.CommitAsync();

            result.Data = wholesalerEntity.Id;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(DeleteWholesalerValidator))]
        public async Task<Result<int>> DeleteWholesaler(DeleteWholesalerVM deleteWholesalerVM)
        {
            var result = new Result<int>();

            var wholesalerExists = await _unitWork.GetRepository<Wholesaler>().AnyAsync(x => x.Id == deleteWholesalerVM.Id);
            if (!wholesalerExists)
            {
                throw new NotFoundException($"{deleteWholesalerVM.Id} numaralı tedarikçi bulunamadı.");
            }

            _unitWork.GetRepository<Wholesaler>().Delete(deleteWholesalerVM.Id);
            await _unitWork.CommitAsync();

            result.Data = deleteWholesalerVM.Id;
            _unitWork.Dispose();
            return result;
        }


        [ValidationBehavior(typeof(UpdateWholesalerValidator))]
        public async Task<Result<int>> UpdateWholesaler(UpdateWholesalerVM updateWholesalerVM)
        {
            var result = new Result<int>();

            var existsWholesaler = await _unitWork.GetRepository<Wholesaler>().GetById(updateWholesalerVM.Id);
            if (existsWholesaler is null)
            {
                throw new NotFoundException($"{updateWholesalerVM} numaralı tedarikçi bulunamadı.");
            }

            var phoneCustomerExists = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.Phone == updateWholesalerVM.Phone);
            if (phoneCustomerExists)
            {
                throw new AlreadyExistsException($"Girmiş olduğunuz telefon numarası kayıtlı. Lütfen numaranızı kontrol ederek tekrar giriniz.");
            }

            var nameWholesalerExists = await _unitWork.GetRepository<Wholesaler>().AnyAsync(x => x.WholesalerName == updateWholesalerVM.WholesalerName && x.Id != updateWholesalerVM.Id);
            if (nameWholesalerExists)
            {
                throw new AlreadyExistsException($"Girmiş olduğunuz tedarikçi adı kayıtlı. Lütfen tedarikçi adını kontrol ederek tekrar giriniz.");
            }

            var phoneWholesalerExists = await _unitWork.GetRepository<Wholesaler>().AnyAsync(x => x.Phone == updateWholesalerVM.Phone && x.Id != updateWholesalerVM.Id);
            if (phoneWholesalerExists)
            {
                throw new AlreadyExistsException($"Girmiş olduğunuz telefon numarası kayıtlı. Lütfen telefon numarası kontrol ederek tekrar giriniz.");
            }

            var updatedWholesaler = _mapper.Map(updateWholesalerVM, existsWholesaler);

            _unitWork.GetRepository<Wholesaler>().Update(updatedWholesaler);
            await _unitWork.CommitAsync();

            result.Data = updatedWholesaler.Id;
            _unitWork.Dispose();
            return result;
        }
    }
}
