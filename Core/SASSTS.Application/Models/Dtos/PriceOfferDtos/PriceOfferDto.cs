using SASSTS.Application.Models.Dtos.CustomerDtos;
using SASSTS.Application.Models.Dtos.ProductDtos;
using SASSTS.Application.Models.Dtos.PurchaseRequestDtos;
using SASSTS.Application.Models.Dtos.WholesalerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Models.Dtos.PriceOfferDtos
{
    public class PriceOfferDto
    {
        public int Id { get; set; }
        public int PurchaseRequestId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int WholesalerId { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public string WholesalerName { get; set; }
        public decimal Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DeliveryDate { get; set; }

        public PurchaseRequestDto PurchaseRequest { get; set; }
        public CustomerDto Customer { get; set; }
        public ProductDto Product { get; set; }
        public WholesalerDto Wholesaler { get; set; }

    }
}
