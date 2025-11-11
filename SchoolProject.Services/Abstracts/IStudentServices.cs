using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services.Abstracts
{
    public interface IStudentServices
    {
        public Task<List<Student>> GetStudentsListAsync();
        public Task<Student> GetStudentByIdWithIncludeAsync(int id);
        public Task<Student> GetStudentByIdAsync(int id);
        public Task<string> AddAsync(Student student);
        public Task<string> DeleteAsync(Student student);
        public Task<string> EditAsync(Student student);
        public Task<bool> IsNameExist(string name);
        public Task<bool> IsNameExistExecludeSelf(string name, int id);
        
        
    }
}
