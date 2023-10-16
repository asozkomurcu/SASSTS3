using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SASSTS.Application.Behaviors;
using SASSTS.Application.Exceptions;
using SASSTS.Application.Models.Dtos.CustomerDtos;
using SASSTS.Application.Models.RequestModels.CategoriesRM;
using SASSTS.Application.Models.RequestModels.CustomerRM;
using SASSTS.Application.Services.Abstraction;
using SASSTS.Application.Validators.CustomerValidators;
using SASSTS.Application.Wrapper;
using SASSTS.Domain.Entities;
using SASSTS.Domain.UWork;

namespace SASSTS.Application.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public CustomerService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        public async Task<Result<List<CustomerDto>>> GetAllCustomers()
        {
            var result = new Result<List<CustomerDto>>();

            var customerEntities = await _unitWork.GetRepository<Customer>().GetAllAsync();
            var customerDtos = await customerEntities.ProjectTo<CustomerDto>(_mapper.ConfigurationProvider).ToListAsync();
            result.Data = customerDtos;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(GetCustomerByIdValidator))]
        public async Task<Result<CustomerDto>> GetCustomerById(GetCustomerByIdVM getCustomerByIdVM)
        {
            var result = new Result<CustomerDto>();

            var customerExists = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.Id == getCustomerByIdVM.Id);
            if (!customerExists)
            {
                throw new NotFoundException($"{getCustomerByIdVM.Id} numaralı personel bulunamadı.");
            }

            var customerEntity = await _unitWork.GetRepository<Customer>().GetById(getCustomerByIdVM.Id);

            var customerDto = _mapper.Map<Customer, CustomerDto>(customerEntity);

            result.Data = customerDto;
            _unitWork.Dispose();
            return result;
        }

        public async Task<Result<CustomerDto>> GetCustomerByName(GetCustomerByNameVM getCustomerByNameVM)
        {
            var result = new Result<CustomerDto>();

            var customerExists = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.Name == getCustomerByNameVM.Name && x.Surname == getCustomerByNameVM.Surname);
            if (!customerExists)
            {
                throw new NotFoundException($"Aradığınız personel bulunamadı.");
            }

            var customerEntity = await _unitWork.GetRepository<Customer>().GetById(getCustomerByNameVM);

            var customerDto = _mapper.Map<Customer, CustomerDto>(customerEntity);

            result.Data = customerDto;
            _unitWork.Dispose();
            return result;

        }

        [ValidationBehavior(typeof(DeleteCustomerValidator))]
        public async Task<Result<int>> DeleteCustomer(DeleteCustomerVM deleteCustomerVM)
        {
            var result = new Result<int>();

            var customerExists = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.Id == deleteCustomerVM.Id);
            if (!customerExists)
            {
                throw new NotFoundException($"{deleteCustomerVM.Id} numaralı personel bulunamadı.");
            }

            _unitWork.GetRepository<Customer>().Delete(deleteCustomerVM.Id);
            await _unitWork.CommitAsync();

            result.Data = deleteCustomerVM.Id;
            _unitWork.Dispose();
            return result;
        }


        [ValidationBehavior(typeof(UpdateCustomerValidator))]
        public async Task<Result<int>> UpdateCustomer(UpdateCustomerVM updateCustomerVM)
        {
            var result = new Result<int>();

            var customerExists = await _unitWork.GetRepository<Customer>().GetById(updateCustomerVM.Id);
            if (customerExists is null)
            {
                throw new NotFoundException($"{updateCustomerVM.Id} numaralı personel bulunamadı.");
            }

            var customerExistsIdentityNumber = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.IdentityNumber == updateCustomerVM.IdentityNumber && x.Id != updateCustomerVM.Id);
            if (customerExistsIdentityNumber)
            {
                throw new AlreadyExistsException($"{updateCustomerVM.IdentityNumber} TC kimlik numarası kayıtlı.");
            }

            var customerExistsPhone = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.Phone == updateCustomerVM.Phone && x.Id != updateCustomerVM.Id);
            if (customerExistsPhone)
            {
                throw new AlreadyExistsException($"{updateCustomerVM.Phone} telefon numarası kayıtlı.");
            }

            var customerExistsEmail = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.Email == updateCustomerVM.Email && x.Id != updateCustomerVM.Id);
            if (customerExistsEmail)
            {
                throw new AlreadyExistsException($"{updateCustomerVM.Email} email adresi kayıtlı.");
            }

            var updateCustomer = _mapper.Map(updateCustomerVM, customerExists);
            _unitWork.GetRepository<Customer>().Update(updateCustomer);
            await _unitWork.CommitAsync();

            result.Data = updateCustomerVM.Id;
            _unitWork.Dispose();
            return result;
        }
    }
}
