using SASSTS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Domain.Entities
{
    public class Wholesaler : DeletetableEntity
    {
        public string WholesalerName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public ICollection<Bill> Bills { get; set; }
        public ICollection<PriceOffer> PriceOffers { get; set; }
        public ICollection<PurchasedProduct> PurchasedProducts { get; set; }

    }
}
