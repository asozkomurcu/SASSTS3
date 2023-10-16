using FluentValidation;
using SASSTS.Application.Models.RequestModels.WholesalersRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Validators.WholesalerValidators
{
    public class UpdateWholesalerValidator : AbstractValidator<UpdateWholesalerVM>
    {
        public UpdateWholesalerValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Tedarikçi kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Tedarikçi kimlik numarası sıfırdan büyük olmalıdır.");
            RuleFor(x => x.WholesalerName)
                .NotEmpty().WithMessage("Tedarikçi adı boş bırakılamaz.")
                .MaximumLength(100).WithMessage("Tedarikçi adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefon numaranızı giriniz.")
                .MinimumLength(11)
                .MaximumLength(11).WithMessage("Telefon numarası 11 hane olmalıdır.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Tedarikçi adres bilgisi boş bırakılamaz.")
                .MaximumLength(500).WithMessage("Tedarikçi adres bilgisi en fazla 500 karakter olabilir.");
        }
    }
}
