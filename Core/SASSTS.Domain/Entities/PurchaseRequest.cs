using SASSTS.Domain.Common;
using SASSTS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Domain.Entities
{
    public class PurchaseRequest : DeletetableEntity
    {
        public PurchaseRequest()
        {
            Products = new List<Product>();
            PriceOffers = new List<PriceOffer>();
        }
        public int ProductId { get; set; }
        public int RequestCustomerId { get; set; }
        public int? OfferCustomerId { get; set; }
        public int? ApprovingCustomerId { get; set; }
        public int? PriceOfferId { get; set; }
        public string RequestCustomerName { get; set; }
        public string? OfferCustomerName { get; set; }
        public string? ApprovingCustomerName { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Amount { get; set; }
        public Status Status { get; set; }

        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public PriceOffer PriceOffer { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<PriceOffer> PriceOffers { get; set; }
        public ICollection<PurchasedProduct> PurchasedProducts { get; set; }
    }
}
