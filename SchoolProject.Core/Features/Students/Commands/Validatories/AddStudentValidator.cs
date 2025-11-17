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
        private readonly IDepartmentServices _departmentServices;

        public AddStudentValidator(IStudentServices studentServices, IDepartmentServices departmentServices)
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
            _studentServices = studentServices;
            _departmentServices = departmentServices;
        }


        public void ApplyValidationsRules()
        {
            RuleFor(S => S.NameEn).NotEmpty().WithMessage("Name Must Not Be Empty")
                .NotNull().WithMessage("Name Must Not Be Null")
                .MaximumLength(10).WithMessage("Max Length Is 10");


            RuleFor(S => S.Address).NotEmpty().WithMessage("{PropertyName}Address Must Not Be Empty")
                .NotNull().WithMessage("{PropertyName} Must Not Be Null")
                .MaximumLength(10).WithMessage("{PropertyName} Length Is 10");


            RuleFor(S => S.DepartmentId).NotEmpty().WithMessage("Name Must Not Be Empty");



        }
        public void ApplyCustomValidationsRules()
        {
            RuleFor( S => S.NameEn).MustAsync(async (Key, CancellationToken) => !await _studentServices.IsNameExist(Key))
                .WithMessage("Name Is Exist");
            RuleFor( S => S.NameAr).MustAsync(async (Key, CancellationToken) => !await _studentServices.IsNameExist(Key))
                .WithMessage("Name Is Exist");

                RuleFor(S => S.DepartmentId).MustAsync(async (Key, CancellationToken) => await _departmentServices.DepartmentIsExist(Key))
              .WithMessage("Department Id Is Exist");
            
            
          
        }
    }
}
