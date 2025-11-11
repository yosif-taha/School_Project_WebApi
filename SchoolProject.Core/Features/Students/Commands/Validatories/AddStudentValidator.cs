using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Services.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Validatories
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentServices _studentServices;

        public AddStudentValidator(IStudentServices studentServices)
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
            _studentServices = studentServices;
        }


        public void ApplyValidationsRules()
        {
            RuleFor(S => S.Name).NotEmpty().WithMessage("Name Must Not Be Empty")
                .NotNull().WithMessage("Name Must Not Be Null")
                .MaximumLength(10).WithMessage("Max Length Is 10");


            RuleFor(S => S.Address).NotEmpty().WithMessage("{PropertyName}Address Must Not Be Empty")
                .NotNull().WithMessage("{PropertyName} Must Not Be Null")
                .MaximumLength(10).WithMessage("{PropertyName} Length Is 10");
        }
        public void ApplyCustomValidationsRules()
        {
            RuleFor( S => S.Name).MustAsync(async (Key, CancellationToken) => !await _studentServices.IsNameExist(Key))
                .WithMessage("Name Is Exist");
        }
    }
}
