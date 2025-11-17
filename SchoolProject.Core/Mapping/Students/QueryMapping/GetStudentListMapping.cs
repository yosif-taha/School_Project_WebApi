using SchoolProject.Core.Features.Student.Queries.Results;
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
        public void GetStudentListMapping()
        {
            CreateMap<Student, GetStudentListResponse>()
        .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(surc => surc.Department.Localized(surc.Department.DepartmentNameEn,surc.Department.DepartmentNameAr)))
        .ForMember(dest => dest.Name, opt => opt.MapFrom(surc => surc.Localized(surc.NameEn,surc.NameAr)));
        }
    }
}
