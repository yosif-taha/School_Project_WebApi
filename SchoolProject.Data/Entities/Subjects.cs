using SchoolProject.Data.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entities
{
    public class Subjects : GeneralLocalizableEntity
    {
        public Subjects()
        {
            StudentsSubjects = new HashSet<StudentSubject>();
            DepartmetsSubjects = new HashSet<DepartmetSubject>();
            InstructorsSubjects = new HashSet<InstructorSubject>();
        }
      
        public int SubjectId { get; set; }
        public string? SubjectNameEn { get; set; }
        public string? SubjectNameAr { get; set; }
        public int? Period { get; set; }
        public virtual ICollection<StudentSubject> StudentsSubjects { get; set; }     
        public virtual ICollection<DepartmetSubject> DepartmetsSubjects { get; set; }
        public virtual ICollection<InstructorSubject> InstructorsSubjects { get; set; }
    }
}
