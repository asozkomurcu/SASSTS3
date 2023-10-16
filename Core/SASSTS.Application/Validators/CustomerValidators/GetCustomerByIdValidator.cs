using FluentValidation;
using SASSTS.Application.Models.RequestModels.CustomerRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Validators.CustomerValidators
{
    public class GetCustomerByIdValidator : AbstractValidator<GetCustomerByIdVM>
    {
        public GetCustomerByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Kullanıcı kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Kullanıcı kimlik numarası sıfırdan büyük olmalıdır.");
        }
    }
}
