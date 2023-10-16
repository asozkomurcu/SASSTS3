using FluentValidation;
using SASSTS.Application.Models.RequestModels.CompaniesRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Validators.CompanyValidators
{
    public class CreateCompanyValidator : AbstractValidator<CreateCompanyVM>
    {
        public CreateCompanyValidator()
        {
            
            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("Şirket adı boş bırakılamaz.")
                .MaximumLength(50).WithMessage("Şirket adı en fazla 50 karakter olabilir.");
        }
    }
}
