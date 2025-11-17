using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entities
{

    public class DepartmetSubject
    {
        public int DepartmentId { get; set; } // Fk for Department Relationship
        public int? SubjectId { get; set; } // Fk for Subject Relationship
        public virtual Department? Department { get; set; }
        public virtual Subjects? Subject { get; set; }
    }
}
