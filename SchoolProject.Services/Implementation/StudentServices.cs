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
    public class StudentServices : IStudentServices
    {
        #region Fields
        private readonly IStudentRepository _studentRepository;
        #endregion

        #region Constractors
        public StudentServices(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

      
        #endregion

        #region Functions

        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _studentRepository.GetStudentsListAsync();
        }
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var student = _studentRepository.GetTableNoTracking().Include(S => S.Department)
                                                                   .Where(S => S.StudentId.Equals(id))
                                                                   .FirstOrDefault();
            return student;
        }

        #endregion
    }
}
