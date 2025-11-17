using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Departments.Queries.Models;
using SchoolProject.Core.Features.Departments.Queries.Results;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities;
using SchoolProject.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Departments.Queries.Handlers
{
    using SchoolProject.Core.Wrapper;
    using SchoolProject.Data.Entities;

    public class DepartmentQueryHandler : ResponseHandler , IRequestHandler<GetDepartmentByIdQuery,Response<GetSingleDepartmentResponse>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IDepartmentServices _departmentServices;
        private readonly IMapper _mapper;
        private readonly IStudentServices _studentServices;

        public DepartmentQueryHandler(IStringLocalizer<SharedResources> stringLocalizer
                                       ,IDepartmentServices departmentServices
                                       ,IMapper mapper
                                       , IStudentServices studentServices) : base(stringLocalizer) 
        {
            _stringLocalizer = stringLocalizer;
            _departmentServices = departmentServices;
            _mapper = mapper;
            _studentServices = studentServices;
        }

        public async Task<Response<GetSingleDepartmentResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            //get services with include
            var response =await _departmentServices.GetByIdAsync(request.Id);
            //check if department exist or not
            if (response == null) return NotFound<GetSingleDepartmentResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            //if exist implement mapping
            var mapper = _mapper.Map<GetSingleDepartmentResponse>(response);
            //Pagination
            Expression<Func<Student, StudentResponse>> expression = S => new StudentResponse(S.StudentId, S.Localized(S.NameEn, S.NameAr));
            var studentQierable = _studentServices.GetStudentsByDepartmentQuerable(request.Id);
            var paginatedList = await studentQierable.Select(expression).ToPaginatedListAsync(request.StudentPageNumber, request.StudentPageSize);
            mapper.StudentList = paginatedList;
            //return response (department)
            return Success(mapper);
        }
    }
}
