using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void EditStudentCommandMapping()
        {
            CreateMap<EditStudentCommand, Student>()
        .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(surc => surc.DepartmentId))
        .ForMember(dest => dest.StudentId, opt => opt.MapFrom(surc => surc.Id));
        }
    }
}
