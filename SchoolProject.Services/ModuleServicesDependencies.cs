using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Services.Abstracts;
using SchoolProject.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services
{
    public static class ModuleServicesDependencies
    {
        public static IServiceCollection AddServicesDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentServices,StudentServices>();
            return services;
        }
    }
}
