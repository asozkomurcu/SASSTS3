using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Models.RequestModels.PurchasedProductsRM
{
    public class CreatePurchasedProductVM
    {
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

    }
}
