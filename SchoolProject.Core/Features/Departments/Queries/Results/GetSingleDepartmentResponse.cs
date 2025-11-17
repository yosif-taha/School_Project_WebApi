using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Departments.Queries.Results
{
    using SchoolProject.Core.Wrapper;
    using SchoolProject.Data.Entities;
    public class GetSingleDepartmentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public PaginatedResult<StudentResponse> StudentList { get; set; }
        public List<InstructorResponse> InstructortList { get; set; }
        public List<SubjectResponse> SubjectList { get; set; }
    }

    public class StudentResponse()
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public StudentResponse(int id , string name) : this ()
        {
            Id = id;
            Name = name;
        }
    }
    public class InstructorResponse()
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class SubjectResponse()
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
