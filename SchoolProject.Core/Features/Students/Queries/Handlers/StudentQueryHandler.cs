using MediatR;
using System.Threading;
using SchoolProject.Core.Features.Student.Queries.Models;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Student.Queries.Handlers
{
    using AutoMapper;
    using SchoolProject.Core.Bases;
    using SchoolProject.Core.Features.Student.Queries.Results;
    using SchoolProject.Core.Features.Students.Queries.Models;
    using SchoolProject.Core.Features.Students.Queries.Results;
    using SchoolProject.Data.Entities;
    using SchoolProject.Services.Abstracts;

    public class StudentQueryHandler :ResponseHandler , IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>, 
                                                          IRequestHandler<GetStudentByIdQuery, Response<GetSingleStudentResponse>>  // use packege of mediator to handle requste and response :- get request from name of model class 'GetStudentListQuery' and response in this case is List<Student>
    {
        #region Fields
        private readonly IStudentServices _studentServices;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public StudentQueryHandler(IStudentServices services, IMapper mapper)
        {
            _studentServices = services;
            _mapper = mapper;
        }
        #endregion

        #region Functions
        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentServices.GetStudentsListAsync();
            var studentListMapper = _mapper.Map<List<GetStudentListResponse>>(studentList);
            return Success(studentListMapper) ;
              
        }

        public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentServices.GetStudentByIdAsync(request.Id);
            if (student == null) return NotFound<GetSingleStudentResponse>("Object Not Found");
            var result = _mapper.Map<GetSingleStudentResponse>(student);
            return Success(result) ;
        }
        #endregion
    }
}
