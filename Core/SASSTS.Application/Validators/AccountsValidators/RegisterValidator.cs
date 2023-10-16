using FluentValidation;
using SASSTS.Application.Models.RequestModels.AccountsRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Validators.AccountsValidators
{
    public class RegisterValidator : AbstractValidator<RegisterVM>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.IdentityNumber)
                .NotEmpty().WithMessage("Tc kimlik boş olamaz.")
                .MaximumLength(11).WithMessage("Tc kimlik numarası 11 karakterden büyük olamaz.")
                .MinimumLength(11).WithMessage("Tc kimlik numarası 11 karakterden küçük olamaz.");

            RuleFor(x => x.DepartmentId)
                .NotEmpty().WithMessage("Departman kimlik numarası boş brakılamaz")
                .GreaterThan(0).WithMessage("Departman kimlik numarası sıfırdan büyük olmalıdır.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ad bilgisi boş olamaz.")
                .MaximumLength(30).WithMessage("Ad bilgisi 30 karakterden büyük olamaz.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Soyad bilgisi boş olamaz.")
                .MaximumLength(30).WithMessage("Soyad bilgisi 30 karakterden büyük olamaz.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Eposta bilgisi boş olamaz.")
                .MaximumLength(150).WithMessage("Eposta bilgisi 150 karakterden büyük olamaz.")
                .EmailAddress().WithMessage("Geçerli bir eposta adresi girmediniz.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefon no bilgisi boş olamaz.")
                .MaximumLength(13).WithMessage("Telefon no bilgisi 13 karakterden büyük olamaz.");

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("Cinsiyet bilgisi boş olamaz.")
                .IsInEnum().WithMessage("Cinsiyet bilgisi geçerli değil. (1 veya 2 olabilir.)");

            RuleFor(x => x.DepartmentName)
                .NotEmpty().WithMessage("Departman adı boş bırakılamaz.")
                .MaximumLength(50).WithMessage("Departman adı en fazla 50 karakter olabilir.");

            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("Kullanıcı yetki bilgisi boş bırakılamaz.")
                .IsInEnum();

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Parola boş olamaz.")
                .MaximumLength(500).WithMessage("Parola en fazla 500 karakter olabilir.");

        }
    }
}
