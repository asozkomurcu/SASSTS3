using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SASSTS.Application.Behaviors;
using SASSTS.Application.Exceptions;
using SASSTS.Application.Models.Dtos.BillsDtos;
using SASSTS.Application.Models.RequestModels.BillsRM;
using SASSTS.Application.Services.Abstraction;
using SASSTS.Application.Validators.BillValidators;
using SASSTS.Application.Wrapper;
using SASSTS.Domain.Entities;
using SASSTS.Domain.UWork;

namespace SASSTS.Application.Services.Implementation
{
    public class BillService : IBillService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public BillService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        public async Task<Result<List<BillDto>>> GetAllBills()
        {
            var result = new Result<List<BillDto>>();

            var billEntities = await _unitWork.GetRepository<Bill>().GetAllAsync();

            var billDtos = await billEntities.ProjectTo<BillDto>(_mapper.ConfigurationProvider).ToListAsync();

            result.Data = billDtos;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(GetBillByIdValidator))]
        public async Task<Result<BillDto>> GetBillById(GetBillByIdVM getBillByIdVM)
        {
            var result = new Result<BillDto>();

            var billExists = await _unitWork.GetRepository<Bill>().AnyAsync(x => x.Id == getBillByIdVM.Id);
            if (!billExists)
            {
                throw new NotFoundException($"{getBillByIdVM.Id} sıra numaralı fatura bulunamadı.");
            }

            var billEntity = await _unitWork.GetRepository<Bill>().GetById(getBillByIdVM.Id);

            var billDto = _mapper.Map<Bill, BillDto>(billEntity);

            result.Data = billDto;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(CreateBillValidator))]
        public async Task<Result<int>> CreateBill(CreateBillVM createBillVM)
        {
            var result = new Result<int>();

            var billExistsSameName = await _unitWork.GetRepository<Bill>().AnyAsync(x => x.BillNumber == createBillVM.BillNumber);
            if (billExistsSameName)
            {
                throw new AlreadyExistsException($"{createBillVM.BillNumber} numaralı fatura kayıtlı.");
            }

            var wholesalerExistsSame = await _unitWork.GetRepository<Wholesaler>().AnyAsync(x => x.WholesalerName == createBillVM.WholesalerName && x.Id == createBillVM.WholesalerId);
            if (!wholesalerExistsSame)
            {
                throw new NotFoundException($"Girilen tedarikçi bilgileri eşleşmiyor veya kayıtlı değil.");
            }

            var productExistsSame = await _unitWork.GetRepository<Product>().AnyAsync(x => x.ProductName == createBillVM.ProductName && x.Id == createBillVM.ProductId);
            if (!productExistsSame)
            {
                throw new NotFoundException($"Girilen personel bilgileri eşleşmiyor veya kayıtlı değil.");
            }

            var billEntity = _mapper.Map<CreateBillVM, Bill>(createBillVM);

            _unitWork.GetRepository<Bill>().Add(billEntity);
            await _unitWork.CommitAsync();

            result.Data = billEntity.Id;
            _unitWork.Dispose();
            return result;
        }


        [ValidationBehavior(typeof(UpdateBillValidator))]
        public async Task<Result<int>> UpdateBill(UpdateBillVM updateBillVM)
        {
            var result = new Result<int>();

            var billExists = await _unitWork.GetRepository<Bill>().GetById(updateBillVM.Id);
            if (billExists is null)
            {
                throw new NotFoundException($"{updateBillVM.Id} sıra numaralı fatura bulunamadı.");
            }

            var wholesalerExistsSame = await _unitWork.GetRepository<Wholesaler>().AnyAsync(x => x.WholesalerName == updateBillVM.WholesalerName && x.Id == updateBillVM.WholesalerId);
            if (!wholesalerExistsSame)
            {
                throw new NotFoundException($"Girilen tedarikçi bilgileri eşleşmiyor veya kayıtlı değil.");
            }

            var productExistsSame = await _unitWork.GetRepository<Product>().AnyAsync(x => x.ProductName == updateBillVM.ProductName && x.Id == updateBillVM.ProductId);
            if (!productExistsSame)
            {
                throw new NotFoundException($"Girilen personel bilgileri eşleşmiyor veya kayıtlı değil.");
            }

            var billUpdate = _mapper.Map(updateBillVM, billExists);

            _unitWork.GetRepository<Bill>().Update(billUpdate);
            await _unitWork.CommitAsync();

            result.Data = billUpdate.Id;
            _unitWork.Dispose();
            return result;
        }
    }
}
