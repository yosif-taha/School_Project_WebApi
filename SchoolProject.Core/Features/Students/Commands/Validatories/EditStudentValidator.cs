using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.Validatories
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        private readonly IStudentServices _studentServices;

        public EditStudentValidator(IStudentServices studentServices)
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
            _studentServices = studentServices;
        }


        public void ApplyValidationsRules()
        {
            RuleFor(S => S.NameEn).NotEmpty().WithMessage("Name Must Not Be Empty")
                .NotNull().WithMessage("Name Must Not Be Null")
                .MaximumLength(100).WithMessage("Max Length Is 10");


            RuleFor(S => S.Address).NotEmpty().WithMessage("{PropertyName}Address Must Not Be Empty")
                .NotNull().WithMessage("{PropertyName} Must Not Be Null")
                .MaximumLength(100).WithMessage("{PropertyName} Length Is 10");
        }
        public void ApplyCustomValidationsRules()
        {
            RuleFor(S => S.NameEn).MustAsync(async (model,Key, CancellationToken) => !await _studentServices.IsNameExistExecludeSelf(Key,model.Id))
                .WithMessage("Name Is Exist");
        }
    }

}
