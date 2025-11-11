using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    using SchoolProject.Data.Entities;
    public class StudentCommsndHandler : ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>
                                                          ,IRequestHandler<EditStudentCommand, Response<string>>
                                                           ,IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        private readonly IStudentServices _services;
        private readonly IMapper _mapper;

        public StudentCommsndHandler(IStudentServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentMapper = _mapper.Map<SchoolProject.Data.Entities.Student>(request);
            var result =  await _services.AddAsync(studentMapper);
        
             if (result == "Success") return Created<string>("Added Is Success");
            else return BadRequest<string>();
         
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _services.GetStudentByIdWithIncludeAsync(request.Id);

            if (student == null) return NotFound<string>("Student is not Found");

            var studentMapper = _mapper.Map<Student>(request);
            var result = await _services.EditAsync(studentMapper);

            if (result == "Success") return Success<string>($"Edit Is Success{studentMapper.StudentId}");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _services.GetStudentByIdAsync(request.Id);

            if (student == null) return NotFound<string>("Student is not Found");

            await _services.DeleteAsync(student);
            return Success<string>("Student Deleted Successfully");
        }
    }
}
