using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entities
{
    public class StudentSubject
    {
        public int? StudentId { get; set; } // Fk For Student Relationship
        public int? SubjectId { get; set; } // Fk For Subject Relationshap
        public decimal? grade { get; set; }
        public virtual Student? Student { get; set; }
        public virtual Subjects? Subject { get; set; }

    }
}
