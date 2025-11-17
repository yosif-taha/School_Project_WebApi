using SchoolProject.Data.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entities
{
    public class Instructor : GeneralLocalizableEntity
    {

        public Instructor()
        {
            InstructorsSubjects = new HashSet<InstructorSubject>();
            Instructors = new HashSet<Instructor>();
        }

        public int InstructorId { get; set; }
        public string? InstructorNameAr { get; set; }
        public string? InstructorNameEn { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }       
        public int? SuperVisorId { get; set; }
        public decimal? Salary { get; set; }       
        public int? DepartmentId { get; set; }       
        public virtual Department? Department { get; set; }       
        public virtual Department? DepartmentManager { get; set; }
        public virtual ICollection<InstructorSubject> InstructorsSubjects { get; set; }        
        public virtual Instructor? SuperVisor { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }




    }
}
