using SASSTS.Application.Models.Dtos.CompanyDtos;
using SASSTS.Application.Models.RequestModels.CompaniesRM;
using SASSTS.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Services.Abstraction
{
    public interface ICompanyService
    {
        Task<Result<List<CompanyDto>>> GetAllCompanies();
        Task<Result<CompanyDto>> GetCompanyById(GetCompanyByIdVM getCompanyByIdVM);
        Task<Result<int>> CreateCompany(CreateCompanyVM createCompanyVM);
        Task<Result<int>> UpdateCompany(UpdateCompanyVM updateCompanyVM);
        Task<Result<int>> DeleteCompany(DeleteCompanyVM deleteCompanyVM);
    }
}
