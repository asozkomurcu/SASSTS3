using FluentValidation;
using SASSTS.Application.Models.RequestModels.PriceOffersRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Validators.PriceOfferValidators
{
    public class GetPriceOfferByIdValidator : AbstractValidator<GetPriceOfferByIdVM>
    {
        public GetPriceOfferByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Gelen teklif kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Gelen teklif kimlik numarası sıfırdan büyük olmalıdır.");
        }
    }
}
