using FluentValidation;
using SASSTS.Application.Models.RequestModels.PurchaseRequestsRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Validators.PurchaseRequestValidators
{
    public class GetPurchaseRequestByIdValidator : AbstractValidator<GetPurchaseRequestByIdVM>
    {
        public GetPurchaseRequestByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Satın alım talep kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Satın alım talep kimlik numarası sıfırdan büyük olmalıdır.");
        }
    }
}
