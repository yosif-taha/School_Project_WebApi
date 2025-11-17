using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entities
{
    public class InstructorSubject
    {
        public int InstructorId { get; set; }
        public int SubjectId { get; set; }
        public virtual Instructor? Instructor { get; set; }
        public virtual Subjects? Subjects { get; set; }


    }
}
