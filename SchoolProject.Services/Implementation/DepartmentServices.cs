using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services.Implementation
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentServices(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<bool> DepartmentIsExist(int departmentId)
        {
           return await _departmentRepository.GetTableNoTracking().AnyAsync(D => D.DepartmentId.Equals(departmentId));
        }

        public async Task<Department> GetByIdAsync(int id)
        {
           var response = await _departmentRepository.GetTableNoTracking().Where(D => D.DepartmentId.Equals(id))
                                                      .Include(D => D.Instructors)
                                                      .Include(D => D.DepartmentSubjects).ThenInclude(DS => DS.Subject)
                                                      .Include(D => D.Instructor)
                                                      .FirstOrDefaultAsync();
            return response;
        }
    }
}
