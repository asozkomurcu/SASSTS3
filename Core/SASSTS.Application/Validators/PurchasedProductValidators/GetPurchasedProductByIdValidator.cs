using FluentValidation;
using SASSTS.Application.Models.RequestModels.PurchasedProductsRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Validators.PurchasedProductValidators
{
    public class GetPurchasedProductByIdValidator : AbstractValidator<GetPurchasedProductByIdVM>
    {
        public GetPurchasedProductByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Satın alınan ürün kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Satın alınan ürün kimlik numarası sıfırdan büyük olmalıdır.");
        }
    }
}
