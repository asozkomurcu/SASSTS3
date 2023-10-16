using FluentValidation;
using SASSTS.Application.Models.RequestModels.CompaniesRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Validators.CompanyValidators
{
    public class UpdateCompanyValidator : AbstractValidator<UpdateCompanyVM>
    {
        public UpdateCompanyValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Şirket kimlik numarası boş brakılamaz.")
                .GreaterThan(0).WithMessage("Şirket kimlik numarası sıfırdan büyük olmalıdır.");

            RuleFor(x => x.CompanyManagerId)
                .NotEmpty().WithMessage("Yönetici kimlik numarası boş brakılamaz.")
                .GreaterThan(0).WithMessage("Yönetici kimlik numarası sıfırdan büyük olmalıdır.");

            RuleFor(x => x.CompanyManagerName)
                .NotEmpty().WithMessage("Yönetici adı boş brakılamaz.")
                .MaximumLength(100).WithMessage("Yönetici adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("Şirket adı boş bırakılamaz.")
                .MaximumLength(50).WithMessage("Şirket adı en fazla 50 karakter olabilir.");
        }
    }
}
