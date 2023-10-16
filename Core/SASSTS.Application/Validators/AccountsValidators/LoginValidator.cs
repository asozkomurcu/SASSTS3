using FluentValidation;
using SASSTS.Application.Models.RequestModels.AccountsRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Validators.AccountsValidators
{
    public class LoginValidator : AbstractValidator<LoginVM>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email alanı boş bırakılamaz.")
                .EmailAddress().WithMessage("Geçersiz email biçimi.")
                .MaximumLength(100).WithMessage("Email adresiniz en fazla 100 karakter olabilir.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre alanı boş bırakılamaz.")
                .MinimumLength(5)
                .MaximumLength(500).WithMessage("Şifre en az 10, en fazla 20 karakter olabilir.");


        }
    }
}
