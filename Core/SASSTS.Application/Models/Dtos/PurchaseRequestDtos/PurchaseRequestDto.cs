using SASSTS.Application.Models.Dtos.CustomerDtos;
using SASSTS.Application.Models.Dtos.PriceOfferDtos;
using SASSTS.Application.Models.Dtos.ProductDtos;
using SASSTS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Models.Dtos.PurchaseRequestDtos
{
    public class PurchaseRequestDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int RequestCustomerId { get; set; }
        public int? OfferCustomerId { get; set; }
        public int? ApprovingCustomerId { get; set; }
        public string RequestCustomerName { get; set; }
        public string? OfferCustomerName { get; set; }
        public string? ApprovingCustomerName { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Amount { get; set; }
        public Status Status { get; set; }
        public int? PriceOfferId { get; set; }

        public ProductDto Product { get; set; }
        public CustomerDto Customer { get; set; }
        public PriceOfferDto PriceOffer { get; set; }


    }
}
