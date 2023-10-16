using SASSTS.Application.Models.Dtos.CustomerDtos;
using SASSTS.Application.Models.Dtos.PriceOfferDtos;
using SASSTS.Application.Models.Dtos.ProductDtos;
using SASSTS.Application.Models.Dtos.PurchaseRequestDtos;
using SASSTS.Application.Models.Dtos.WholesalerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Models.Dtos.PurchasedProductDtos
{
    public class PurchasedProductDto
    {
        public int Id { get; set; }
        public int PurchaseRequestId { get; set; }
        public int PriceOfferId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int WholesalerId { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public decimal Amount { get; set; }
        public string WholesalerName { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public DateTime DeliveryDate { get; set; }

        public PurchaseRequestDto PurchaseRequest { get; set; }
        public PriceOfferDto PriceOffers { get; set; }
        public CustomerDto Customer { get; set; }
        public ProductDto Product { get; set; }
        public WholesalerDto Wholesaler { get; set; }

    }
}