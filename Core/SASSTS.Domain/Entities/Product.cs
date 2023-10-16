using SASSTS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Domain.Entities
{
    public class Product : DeletetableEntity
    {
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public decimal Amount { get; set; }
        public decimal UnitPrice { get; set; }


        public Category Category { get; set; }

        public ICollection<Bill> Bills { get; set; }
        public ICollection<PriceOffer> PriceOffers { get; set; }
        public ICollection<PurchasedProduct> PurchasedProducts { get; set; }
        public ICollection<PurchaseRequest> PurchaseRequests { get; set; }

    }
}
