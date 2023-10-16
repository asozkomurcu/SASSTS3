using FluentValidation;
using SASSTS.Application.Models.RequestModels.DepartmentsRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Validators.DepartmentValidators
{
    public class UpdateDepartmentValidator : AbstractValidator<UpdateDepartmentVM>
    {
        public UpdateDepartmentValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Departman kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Departman kimlik numarası sıfırdan büyük olmalıdır.");

            RuleFor(x => x.CompanyId)
                .NotEmpty().WithMessage("Şirket kimlik numarası boş brakılamaz.")
                .GreaterThan(0).WithMessage("Şirket kimlik numarası sıfırdan büyük olmalıdır.");

            RuleFor(x => x.DepartmentManagerId)
                .NotEmpty().WithMessage("Yönetici kimlik numarası boş brakılamaz.")
                .GreaterThan(0).WithMessage("Yönetici kimlik numarası sıfırdan büyük olmalıdır.");

            RuleFor(x => x.DepartmentManagerName)
                .NotEmpty().WithMessage("Yönetici adı boş brakılamaz.")
                .MaximumLength(100).WithMessage("Yönetici adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.DepartmentName)
                .NotEmpty().WithMessage("Departman adı boş bırakılamaz.")
                .MaximumLength(50).WithMessage("Departman adı en fazla 50 karakter olabilir.");

            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("Şirket adı boş bırakılamaz.")
                .MaximumLength(50).WithMessage("Şirket adı en fazla 50 karakter olabilir.");
        }
    }
}
