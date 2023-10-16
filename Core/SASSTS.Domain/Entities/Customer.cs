using SASSTS.Domain.Common;
using SASSTS.Domain.Entities;

namespace SASSTS.Domain.Entities
{
    public class Customer : DeletetableEntity
    {
        public string IdentityNumber { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public string Password { get; set; }
        public string DepartmentName { get; set; }
        public Roles Role { get; set; }
        public UserAuthorizations? UserAuthorizations { get; set; }

        public Account Account { get; set; }
        public Department Department { get; set; }

        public ICollection<PriceOffer> PriceOffers { get; set; }
        public ICollection<PurchasedProduct> PurchasedProducts { get; set; }
        public ICollection<PurchaseRequest> PurchaseRequests { get; set; }
        public ICollection<Company> Companies { get; set; }
        public ICollection<Department> Departments { get; set; }


    }
}
