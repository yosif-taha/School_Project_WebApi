using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entities
{
    public class Student
    {

        public Student()
        {
            StudentSubject = new HashSet<StudentSubject>();
        }

        [Key]
        public int StudentID { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Address { get; set; }
        [StringLength(500)]
        public string Phone { get; set; }
        public int? DepartmentId { get; set; }  // Fk For Department Relationship 

        public virtual Department Department { get; set; }

        public ICollection<StudentSubject> StudentSubject { get; set; }
    }
}
