using SASSTS.Application.Models.Dtos.CustomerDtos;
using SASSTS.Application.Models.RequestModels.CustomerRM;
using SASSTS.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Services.Abstraction
{
    public interface ICustomerService
    {
        Task<Result<List<CustomerDto>>> GetAllCustomers();
        Task<Result<CustomerDto>> GetCustomerById(GetCustomerByIdVM getCustomerByIdVM);
        Task<Result<CustomerDto>> GetCustomerByName(GetCustomerByNameVM getCustomerByNameVM);
        Task<Result<int>> UpdateCustomer(UpdateCustomerVM updateCustomerVM);
        Task<Result<int>> DeleteCustomer(DeleteCustomerVM deleteCustomerVM);
    }
}
