using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Domain.Entities
{
    public enum Roles
    {
        User = 1,
        Accounting = 2,
        ProductManager= 3,
        DepartmentManager = 4,
        CompanyManager = 5,
        Admin = 6
    }

    public enum Status
    {
        Created = 1, // oluşturuldu
        Waiting = 2, // bekliyor
        Approved = 3 // onaylandı
    }

    public enum Gender
    {
        Male = 1,
        Famale = 2
    }

    public enum UserAuthorizations
    {
        RequestPerson = 1, //sadece talep oluşturabilecek kullanıcı
        OfferRecipient = 2, //teklif toplama ve alım yapabilecek kullanıcı
        MinApprove = 3, //min belirli tutara kadar onaylayan yetkili
        MaxApprove = 4 //max tutarı onaylayabilen yetkili
    }
}
