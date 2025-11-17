using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services.Abstracts
{
    public interface IDepartmentServices
    {
        public Task<Department> GetByIdAsync(int id);
       public Task<bool> DepartmentIsExist(int departmentId);
    }
}
