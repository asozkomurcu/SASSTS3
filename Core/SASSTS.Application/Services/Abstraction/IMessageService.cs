using SASSTS.Application.Models.RequestModels.AccountsRM;
using SASSTS.Application.Models.RequestModels.PurchasedProductsRM;
using SASSTS.Application.Models.RequestModels.PurchaseRequestsRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Services.Abstraction
{
    public interface IMessageService
    {
        string SubjectMessage();
        string RegisterMessage(RegisterVM createUserVM);
        string RegisterMessage(CreatePurchaseRequestVM createPurchaseRequestVM);
        string RegisterMessage(UpdatePurchaseRequestVM updatePurchaseRequestVM);
        //string RegisterMessage(CreatePurchasedProductVM createPurchasedProductVM);

        string SubjectPurchaseRequestMessage();
        string SubjectUpdatePurchaseRequestMessage();
    }
}
