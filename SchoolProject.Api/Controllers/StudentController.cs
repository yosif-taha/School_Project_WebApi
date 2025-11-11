using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Student.Queries.Models;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMetaData;
using System.Threading.Tasks;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class StudentController : AppControllerBase
    {

        public StudentController()
        {
            
        }
        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetStudentList()
        {
            var response = await Mediator.Send(new GetStudentListQuery());
            return Ok(response);
        }

        [HttpGet(Router.StudentRouting.GetById)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetStudentByIdQuery(id));
            return NewResult(response);
        }
        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut(Router.StudentRouting.Edit)]
        public async Task<IActionResult> EditStudent([FromBody] EditStudentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete(Router.StudentRouting.Delete)]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteStudentCommand(id));
            return NewResult(response);
        }
    }
}
