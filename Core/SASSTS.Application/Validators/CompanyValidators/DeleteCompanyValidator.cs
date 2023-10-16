using FluentValidation;
using SASSTS.Application.Models.RequestModels.CompaniesRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Validators.CompanyValidators
{
    public class DeleteCompanyValidator : AbstractValidator<DeleteCompanyVM>
    {
        public DeleteCompanyValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Şirket kimlik numarası boş brakılamaz.")
                .GreaterThan(0).WithMessage("Şirket kimlik numarası sıfırdan büyük olmalıdır.");
        }
    }
}
