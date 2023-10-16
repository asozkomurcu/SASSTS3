using AutoMapper;
using SASSTS.Application.Models.Dtos.AccountDtos;
using SASSTS.Application.Models.Dtos.BillsDtos;
using SASSTS.Application.Models.Dtos.CategoryDtos;
using SASSTS.Application.Models.Dtos.CompanyDtos;
using SASSTS.Application.Models.Dtos.CustomerDtos;
using SASSTS.Application.Models.Dtos.DepartmentDtos;
using SASSTS.Application.Models.Dtos.PriceOfferDtos;
using SASSTS.Application.Models.Dtos.ProductDtos;
using SASSTS.Application.Models.Dtos.PurchasedProductDtos;
using SASSTS.Application.Models.Dtos.PurchaseRequestDtos;
using SASSTS.Application.Models.Dtos.WholesalerDtos;
using SASSTS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Automappings
{
    public class DomainToDto : Profile
    {
        public DomainToDto()
        {
            CreateMap<Account, AccountDto>();

            CreateMap<Bill, BillDto>();

            CreateMap<Category, CategoryDto>();

            CreateMap<Company, CompanyDto>()
                .ForMember(x => x.CompanyManagerId, y => y.MapFrom(e => e.Customer.Id));

            CreateMap<Customer, CustomerDto>();

            CreateMap<Department, DepartmentDto>()
                .ForMember(x => x.DepartmentManagerId, y => y.MapFrom(e => e.Customer.Id));

            CreateMap<PriceOffer, PriceOfferDto>()
                .ForMember(x => x.CustomerName, y => y.MapFrom(e => e.Customer.Name + ' ' + e.Customer.Surname));

            CreateMap<Product, ProductDto>();

            CreateMap<PurchasedProduct, PurchasedProductDto>()
                .ForMember(x => x.CustomerName, y => y.MapFrom(e => e.Customer.Name + ' ' + e.Customer.Surname));

            CreateMap<PurchaseRequest, PurchaseRequestDto>()
                .ForMember(x => x.RequestCustomerId, y => y.MapFrom(e => e.Customer.Id))
                .ForMember(x => x.RequestCustomerName, y => y.MapFrom(e => e.Customer.Name + ' ' + e.Customer.Surname))
                .ForMember(x => x.OfferCustomerId, y => y.MapFrom(e => e.Customer.Id))
                .ForMember(x => x.OfferCustomerName, y => y.MapFrom(e => e.Customer.Name + ' ' + e.Customer.Surname))
                .ForMember(x => x.ApprovingCustomerId, y => y.MapFrom(e => e.Customer.Id))
                .ForMember(x => x.ApprovingCustomerName, y => y.MapFrom(e => e.Customer.Name + ' ' + e.Customer.Surname));

            CreateMap<Wholesaler, WholesalerDto>();

        }
    }
}
