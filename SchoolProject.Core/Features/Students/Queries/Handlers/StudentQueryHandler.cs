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
    using Microsoft.Extensions.Localization;
    using SchoolProject.Core.Bases;
    using SchoolProject.Core.Features.Student.Queries.Results;
    using SchoolProject.Core.Features.Students.Queries.Models;
    using SchoolProject.Core.Features.Students.Queries.Results;
    using SchoolProject.Core.Resources;
    using SchoolProject.Core.Wrapper;
    using SchoolProject.Data.Entities;
    using SchoolProject.Services.Abstracts;
    using System.Linq.Expressions;

    public class StudentQueryHandler :ResponseHandler , IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>
                                                         , IRequestHandler<GetStudentByIdQuery, Response<GetSingleStudentResponse>>  // use packege of mediator to handle requste and response :- get request from name of model class 'GetStudentListQuery' and response in this case is List<Student>
                                                         , IRequestHandler<GetStudentPAginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>> // use packege of mediator to handle requste and response :- get request from name of model class 'GetStudentListQuery' and response in this case is List<Student>
    {                                                     
        #region Fields
        private readonly IStudentServices _studentServices;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalization;
        #endregion

        #region Constructors
        public StudentQueryHandler(IStudentServices services, 
                                  IMapper mapper, 
                                  IStringLocalizer<SharedResources> stringLocalizer): base(stringLocalizer)
        {
            _studentServices = services;
            _mapper = mapper;
            _stringLocalization = stringLocalizer;
        }
        #endregion

        #region Functions
        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentServices.GetStudentsListAsync();
            var studentListMapper = _mapper.Map<List<GetStudentListResponse>>(studentList);
            var result = Success(studentListMapper) ;
            result.Meta = new {Count = studentListMapper.Count()};
            return result;
        }

        public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentServices.GetStudentByIdAsync(request.Id);
            if (student == null) return NotFound<GetSingleStudentResponse>(_stringLocalization[SharedResourcesKeys.NotFound]);
            var result = _mapper.Map<GetSingleStudentResponse>(student);
            return Success(result) ;
        }

        public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPAginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentPaginatedListResponse>> expression = S => new GetStudentPaginatedListResponse(S.StudentId,S.Localized(S.NameEn,S.NameAr),S.Address,S.Department.Localized(S.Department.DepartmentNameEn,S.Department.DepartmentNameAr));
           // var querable = _studentServices.GetStudentsQuerable();
            var filterQuery = _studentServices.FilterStudentPaginatedQuerabl(request.OrderBy,request.Search);
            var paginatedList = await filterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
             paginatedList.Meta = new { Count = paginatedList.Data.Count()};
            return paginatedList;
        }
        #endregion
    }
}
