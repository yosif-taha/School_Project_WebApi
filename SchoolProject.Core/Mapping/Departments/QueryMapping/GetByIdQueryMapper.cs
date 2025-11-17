using AutoMapper;
using SchoolProject.Core.Features.Departments.Queries.Results;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.Departments
{
    public partial class DepartmentProfile 
    {
        public void GetByIdQueryMapper()
        {
            CreateMap<Department, GetSingleDepartmentResponse>()
                .ForMember(Des => Des.Id, Opt => Opt.MapFrom(Surc => Surc.DepartmentId))
                .ForMember(Des => Des.Name, Opt => Opt.MapFrom(Surc => Surc.Localized(Surc.DepartmentNameEn, Surc.DepartmentNameAr)))
                .ForMember(Des => Des.ManagerName, Opt => Opt.MapFrom(Surc => Surc.Instructor.Localized(Surc.Instructor.InstructorNameEn,Surc.Instructor.InstructorNameAr)))
                //.ForMember(Des => Des.StudentList, Opt => Opt.MapFrom(Surc => Surc.Students))
                .ForMember(Des => Des.InstructortList, Opt => Opt.MapFrom(Surc => Surc.Instructors))
                .ForMember(Des => Des.SubjectList, Opt => Opt.MapFrom(Surc => Surc.DepartmentSubjects));



            CreateMap<DepartmetSubject, SubjectResponse>()
               .ForMember(Des => Des.Id, OPt => OPt.MapFrom(Surc => Surc.SubjectId))
               .ForMember(Des => Des.Name, OPt => OPt.MapFrom(Surc => Surc.Subject.Localized(Surc.Subject.SubjectNameEn, Surc.Subject.SubjectNameAr)));


               //CreateMap<Student, StudentResponse>()
               //.ForMember(Des => Des.Id, OPt => OPt.MapFrom(Surc => Surc.StudentId))
               //.ForMember(Des => Des.Name, OPt => OPt.MapFrom(Surc => Surc.Localized(Surc.NameEn, Surc.NameAr)));

            CreateMap<Instructor, InstructorResponse>()
            .ForMember(Des => Des.Id, OPt => OPt.MapFrom(Surc => Surc.InstructorId))
            .ForMember(Des => Des.Name, OPt => OPt.MapFrom(Surc => Surc.Localized(Surc.InstructorNameEn, Surc.InstructorNameAr)));

                
        }
    }

}
