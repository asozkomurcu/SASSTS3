using SASSTS.Domain.Entities;

namespace SASSTS.Application.Models.RequestModels.PurchaseRequestsRM
{
    public class CreatePurchaseRequestVM
    {
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

    }
}
