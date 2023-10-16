using SASSTS.Application.Models.RequestModels.AccountsRM;
using SASSTS.Application.Models.RequestModels.PurchasedProductsRM;
using SASSTS.Application.Models.RequestModels.PurchaseRequestsRM;
using SASSTS.Application.Services.Abstraction;
using SASSTS.Domain.Entities;

namespace SASSTS.Application.Services.Implementation
{
    public class MessageService : IMessageService
    {
        public string RegisterMessage(RegisterVM createUserVM)
        {
            var message = ($"Sayın {createUserVM.Name.ToUpper()} {createUserVM.Surname.ToUpper()}.  Personel kayıt işleminiz tamamlandı.   Giriş bilgileriniz :     Kullanıcı adı :{createUserVM.Email}Şifreniz : {createUserVM.Password} Lütfen en kısa sürede şifrenizi değiştiriniz.");
            return message;
        }

        public string SubjectMessage()
        {
            var message = "ARAMIZA HOŞGELDİNİZ";
            return message;
        }
        public string SubjectPurchaseRequestMessage()
        {
            var message = "Satın Alım ";
            return message;
        }
        public string SubjectUpdatePurchaseRequestMessage()
        {
            var message = "Satın Alım Talep Onayı ";
            return message;
        }

        public string RegisterMessage(CreatePurchaseRequestVM createPurchaseRequestVM)
        {
            var message = $"Sayın {createPurchaseRequestVM.OfferCustomerName.ToUpper()}. Bir adet satın alım talebi girildi. Fiyat teklifleri toplamaya başlayabilirsiniz.";
            return message;
        }

        public string RegisterMessage(UpdatePurchaseRequestVM updatePurchaseRequestVM)
        {
            throw new NotImplementedException();
        }


        //public string RegisterMessage(CreatePurchasedProductVM createPurchasedProductVM)
        //{

        //    var message = $"Sayın {createPurchasedProductVM.}. Bir adet satın alım talep onayı bekleniyor.";
        //    return message;
        //}

    }
}
