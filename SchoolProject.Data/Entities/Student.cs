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
    public class Student : GeneralLocalizableEntity

    {

        public Student()
        {
            StudentSubject = new HashSet<StudentSubject>();
        }

        public int StudentId { get; set; }
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public int? DepartmentId { get; set; }  // Fk For Department Relationship 
        public virtual Department? Department { get; set; }
        public virtual ICollection<StudentSubject> StudentSubject { get; set; }
    }
}
