using SASSTS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Domain.Entities
{
    public class Bill : AuditableEntity
    {
        public Bill()
        {
            Products = new List<Product>();
        }

        public int WholesalerId { get; set; }
        public int ProductId { get; set; }
        public DateTime BillDate { get; set; }
        public string BillNumber { get; set; }
        public string BillType { get; set; }
        public string WholesalerName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int KDV { get; set; }
        public decimal? Discount { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public decimal TotalUnitPrice { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal TotalKDV { get; set; }
        public decimal TotalPrice { get; set; }

        public Wholesaler Wholesaler { get; set; }
        public Product Product { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
