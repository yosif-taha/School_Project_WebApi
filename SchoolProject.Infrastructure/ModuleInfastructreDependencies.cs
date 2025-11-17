using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.InfrastructureBases;
using SchoolProject.Infrastructure.Repositories;

namespace SchoolProject.Infrastructure
{
    public static class ModuleInfastructreDependencies
    {

        public static IServiceCollection AddInfastructreDependencies(this IServiceCollection services)  // This Is Extenssion Method :- To add this fun name 'AddInfastructreDependencies' to services in program.cs 
        {
            services.AddTransient<IStudentRepository,StudentRepository>();
            services.AddTransient<IDepartmentRepository,DepartmentRepository>();
            services.AddTransient<IInstructorRepository,InstructorRepository>();
            services.AddTransient<ISubjectRepository,SubjectRepository>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            return services;
        }
    }
}
