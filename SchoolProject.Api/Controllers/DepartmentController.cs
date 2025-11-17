using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Departments.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMetaData;
using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolProject.Core.Features.Student.Queries.Models;
using SchoolProject.Core.Features.Students.Commands.Models;
namespace SchoolProject.Api.Controllers
{
    
    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        [HttpGet(Routers.DepartmentRouting.GetById)]
        public async Task<IActionResult> GetDepartmentById([FromQuery] GetDepartmentByIdQuery query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }
    }
}
