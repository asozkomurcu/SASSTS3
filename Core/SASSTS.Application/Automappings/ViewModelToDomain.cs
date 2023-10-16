using AutoMapper;
using SASSTS.Application.Models.RequestModels.AccountsRM;
using SASSTS.Application.Models.RequestModels.BillsRM;
using SASSTS.Application.Models.RequestModels.CategoriesRM;
using SASSTS.Application.Models.RequestModels.CompaniesRM;
using SASSTS.Application.Models.RequestModels.CustomerRM;
using SASSTS.Application.Models.RequestModels.DepartmentsRM;
using SASSTS.Application.Models.RequestModels.PriceOffersRM;
using SASSTS.Application.Models.RequestModels.ProductsRM;
using SASSTS.Application.Models.RequestModels.PurchasedProductsRM;
using SASSTS.Application.Models.RequestModels.PurchaseRequestsRM;
using SASSTS.Application.Models.RequestModels.WholesalersRM;
using SASSTS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Automappings
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            //Personel oluşturma
            CreateMap<RegisterVM, Customer>()
            .ForMember(x => x.Name, y => y.MapFrom(e => e.Name.ToUpper().Trim()))
            .ForMember(x => x.Surname, y => y.MapFrom(e => e.Surname.ToUpper().Trim()))
            .ForMember(x => x.Email, y => y.MapFrom(e => e.Email.Trim()))
            .ForMember(x => x.DepartmentName, y => y.MapFrom(e => e.DepartmentName.ToUpper().Trim()));
            CreateMap<RegisterVM, Account>()
                .ForMember(x => x.Email, y => y.MapFrom(e => e.Email.Trim()));
            CreateMap<UpdateUserVM, Customer>()
                .ForMember(x => x.Email, y => y.MapFrom(e => e.Email.Trim()));


            //Account
            CreateMap<UpdateUserVM, Account>()
                .ForMember(x => x.Email, y => y.MapFrom(e => e.Email.Trim()));
            CreateMap<UpdateCustomerVM, Account>()
                .ForMember(x => x.Email, y => y.MapFrom(e => e.Email.Trim()));

            //Bill
            CreateMap<CreateBillVM, Bill>()
                .ForMember(x => x.WholesalerName, y => y.MapFrom(e => e.WholesalerName.ToUpper().Trim()))
                .ForMember(x => x.ProductName, y => y.MapFrom(e => e.ProductName.ToUpper().Trim()));
            CreateMap<GetBillByIdVM, Bill>();
            CreateMap<UpdateBillVM, Bill>()
                .ForMember(x => x.WholesalerName, y => y.MapFrom(e => e.WholesalerName.ToUpper().Trim()))
                .ForMember(x => x.ProductName, y => y.MapFrom(e => e.ProductName.ToUpper().Trim()));

            //Category
            CreateMap<CreateCategoryVM, Category>()
                .ForMember(x => x.CategoryName, y => y.MapFrom(e => e.CategoryName.ToUpper().Trim()));
            CreateMap<DeleteCategoryVM, Category>();
            CreateMap<GetCategoryByIdVM, Category>();
            CreateMap<UpdateCategoryVM, Category>()
                .ForMember(x => x.CategoryName, y => y.MapFrom(e => e.CategoryName.ToUpper().Trim()));

            //Company
            CreateMap<CreateCompanyVM, Company>()
                //.ForMember(x => x.CompanyManagerName, y => y.MapFrom(e => e.CompanyManagerName.ToUpper().Trim()))
                .ForMember(x => x.CompanyName, y => y.MapFrom(e => e.CompanyName.ToUpper().Trim()));
            CreateMap<DeleteCompanyVM, Company>();
            CreateMap<GetCompanyByIdVM, Company>();
            CreateMap<UpdateCompanyVM, Company>()
                .ForMember(x => x.CompanyManagerName, y => y.MapFrom(e => e.CompanyManagerName.ToUpper().Trim()))
                .ForMember(x => x.CompanyName, y => y.MapFrom(e => e.CompanyName.ToUpper().Trim()));

            //Customer
            CreateMap<DeleteCustomerVM, Customer>();
            CreateMap<GetCustomerByIdVM, Customer>();
            CreateMap<GetCustomerByNameVM, Customer>();
            CreateMap<UpdateCustomerVM, Customer>()
                .ForMember(x => x.Name, y => y.MapFrom(e => e.Name.ToUpper().Trim()))
                .ForMember(x => x.Surname, y => y.MapFrom(e => e.Surname.ToUpper().Trim()))
                .ForMember(x => x.Email, y => y.MapFrom(e => e.Email.Trim()))
                .ForMember(x => x.DepartmentName, y => y.MapFrom(e => e.DepartmentName.ToUpper().Trim()));

            //Department
            CreateMap<CreateDepartmentVM, Department>()
                .ForMember(x => x.DepartmentName, y => y.MapFrom(e => e.DepartmentName.ToUpper().Trim()))
                //.ForMember(x => x.DepartmentManagerName, y => y.MapFrom(e => e.DepartmentManagerName.ToUpper().Trim()))
                .ForMember(x => x.CompanyName, y => y.MapFrom(e => e.CompanyName.ToUpper().Trim()));
            CreateMap<DeleteDepartmentVM, Department>();
            CreateMap<GetDepartmentByIdVM, Department>();
            CreateMap<UpdateDepartmentVM, Department>()
                .ForMember(x => x.DepartmentName, y => y.MapFrom(e => e.DepartmentName.ToUpper().Trim()))
                .ForMember(x => x.DepartmentManagerName, y => y.MapFrom(e => e.DepartmentManagerName.ToUpper().Trim()))
                .ForMember(x => x.CompanyName, y => y.MapFrom(e => e.CompanyName.ToUpper().Trim()));


            //PriceOffer
            CreateMap<CreatePriceOfferVM, PriceOffer>()
                .ForMember(x => x.CustomerName, y => y.MapFrom(e => e.CustomerName.ToUpper().Trim()))
                .ForMember(x => x.ProductName, y => y.MapFrom(e => e.ProductName.ToUpper().Trim()))
                .ForMember(x => x.WholesalerName, y => y.MapFrom(e => e.WholesalerName.ToUpper().Trim()));
            CreateMap<DeletePriceOfferVM, PriceOffer>();
            CreateMap<GetPriceOfferByIdVM, PriceOffer>();
            CreateMap<UpdatePriceOfferVM, PriceOffer>()
                .ForMember(x => x.CustomerName, y => y.MapFrom(e => e.CustomerName.ToUpper().Trim()))
                .ForMember(x => x.ProductName, y => y.MapFrom(e => e.ProductName.ToUpper().Trim()))
                .ForMember(x => x.WholesalerName, y => y.MapFrom(e => e.WholesalerName.ToUpper().Trim()));

            //Product
            CreateMap<CreateProductVM, Product>()
                .ForMember(x => x.ProductName, y => y.MapFrom(e => e.ProductName.ToUpper().Trim()))
                .ForMember(x => x.CategoryName, y => y.MapFrom(e => e.CategoryName.ToUpper().Trim()));
            CreateMap<DeleteProductVM, Product>();
            CreateMap<GetProductByIdVM, Product>();
            CreateMap<UpdateProductVM, Product>()
                .ForMember(x => x.ProductName, y => y.MapFrom(e => e.ProductName.ToUpper().Trim()))
                .ForMember(x => x.CategoryName, y => y.MapFrom(e => e.CategoryName.ToUpper().Trim()));

            //PurchasedProduct
            CreateMap<CreatePurchasedProductVM, PurchasedProduct>()
                .ForMember(x => x.CustomerName, y => y.MapFrom(e => e.CustomerName.ToUpper().Trim()))
                .ForMember(x => x.ProductName, y => y.MapFrom(e => e.ProductName.ToUpper().Trim()))
                .ForMember(x => x.WholesalerName, y => y.MapFrom(e => e.WholesalerName.ToUpper().Trim()));
            CreateMap<GetPurchasedProductByIdVM, PurchasedProduct>();
            CreateMap<UpdatePurchasedProductVM, PurchasedProduct>()
                .ForMember(x => x.CustomerName, y => y.MapFrom(e => e.CustomerName.ToUpper().Trim()))
                .ForMember(x => x.ProductName, y => y.MapFrom(e => e.ProductName.ToUpper().Trim()))
                .ForMember(x => x.WholesalerName, y => y.MapFrom(e => e.WholesalerName.ToUpper().Trim()));

            //PurchaseRequest
            CreateMap<CreatePurchaseRequestVM, PurchaseRequest>()
                .ForMember(x => x.RequestCustomerName, y => y.MapFrom(e => e.RequestCustomerName.ToUpper().Trim()))
                .ForMember(x => x.OfferCustomerName, y => y.MapFrom(e => e.OfferCustomerName.ToUpper().Trim()))
                .ForMember(x => x.ApprovingCustomerName, y => y.MapFrom(e => e.ApprovingCustomerName.ToUpper().Trim()));
            CreateMap<DeletePurchaseRequestVM, PurchaseRequest>();
            CreateMap<GetPurchaseRequestByIdVM, PurchaseRequest>();
            CreateMap<UpdatePurchaseRequestVM, PurchaseRequest>();
                //.ForMember(x => x.RequestCustomerName, y => y.MapFrom(e => e.RequestCustomerName.ToUpper().Trim()))
                //.ForMember(x => x.OfferCustomerName, y => y.MapFrom(e => e.OfferCustomerName.ToUpper().Trim()))
                //.ForMember(x => x.ApprovingCustomerName, y => y.MapFrom(e => e.ApprovingCustomerName.ToUpper().Trim()));

            //Wholesaler
            CreateMap<CreateWholesalerVM, Wholesaler>()
            .ForMember(x => x.WholesalerName, y => y.MapFrom(e => e.WholesalerName.ToUpper().Trim()))
                .ForMember(x => x.Address, y => y.MapFrom(e => e.Address.ToUpper().Trim()));
            CreateMap<DeleteWholesalerVM, Wholesaler>();
            CreateMap<GetWholesalerByIdVM, Wholesaler>();
            CreateMap<UpdateWholesalerVM, Wholesaler>()
                .ForMember(x => x.WholesalerName, y => y.MapFrom(e => e.WholesalerName.ToUpper().Trim()))
                .ForMember(x => x.Address, y => y.MapFrom(e => e.Address.ToUpper().Trim()));



        }
    }
}
