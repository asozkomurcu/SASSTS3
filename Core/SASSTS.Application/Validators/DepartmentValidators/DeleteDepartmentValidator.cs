using FluentValidation;
using SASSTS.Application.Models.RequestModels.DepartmentsRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Validators.DepartmentValidators
{
    public class DeleteDepartmentValidator : AbstractValidator<DeleteDepartmentVM>
    {
        public DeleteDepartmentValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Departman kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Departman kimlik numarası sıfırdan büyük olmalıdır.");
        }
    }
}
