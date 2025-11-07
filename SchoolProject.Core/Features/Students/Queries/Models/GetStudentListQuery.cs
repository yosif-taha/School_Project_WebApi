using MediatR;
using SchoolProject.Data.Entities;
using SchoolProject.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Student.Queries.Models
{
    using SchoolProject.Core.Features.Student.Queries.Results;
    using SchoolProject.Data.Entities;
    public class GetStudentListQuery : IRequest<Response<List<GetStudentListResponse>>> // This line use Package of mediator to refer request is 'GetStudentListQuery' and response list<student> 
    {
    }
}
