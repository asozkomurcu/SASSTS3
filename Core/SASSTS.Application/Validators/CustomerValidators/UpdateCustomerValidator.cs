using FluentValidation;
using SASSTS.Application.Models.RequestModels.CustomerRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Validators.CustomerValidators
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerVM>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Kullanıcı kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Kullanıcı kimlik numarası sıfırdan büyük olmalıdır.");

            RuleFor(x => x.IdentityNumber)
                .NotEmpty().WithMessage("Personel TC kimlik numarası boş brakılamaz")
                .MinimumLength(11)
                .MaximumLength(11).WithMessage("Personel TC kimlik numarası 11 haneden oluşmalıdır.");

            RuleFor(x => x.DepartmentId)
                .NotEmpty().WithMessage("Departman kimlik numarası boş brakılamaz")
                .GreaterThan(0).WithMessage("Departman kimlik numarası sıfırdan büyük olmalıdır.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Personel adı boş bırakılamaz.")
                .MaximumLength(50).WithMessage("Personel adı en fazla 50 karakter olabilir.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Personel soyadı boş bırakılamaz.")
                .MaximumLength(50).WithMessage("Personel soyadı en fazla 50 karakter olabilir.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email alanı boş bırakılamaz.")
                .EmailAddress().WithMessage("Geçersiz email biçimi.")
                .MaximumLength(100).WithMessage("Email adresiniz en fazla 100 karakter olabilir.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefon numaranızı giriniz.")
                .MinimumLength(11)
                .MaximumLength(11).WithMessage("Telefon numarası 11 hane olmalıdır.");

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("Cinsiyet alanı boş bırakılamaz.")
                .IsInEnum();

            RuleFor(x => x.DepartmentName)
                .NotEmpty().WithMessage("Departman adı boş bırakılamaz.")
                .MaximumLength(50).WithMessage("Departman adı en fazla 50 karakter olabilir.");

            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("Kullanıcı yetki bilgisi boş bırakılamaz.")
                .IsInEnum();
        }
    }
}
