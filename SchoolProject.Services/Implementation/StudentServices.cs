using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Helppers;
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
        public async Task<Student> GetStudentByIdWithIncludeAsync(int id)
        {
            var student = _studentRepository.GetTableNoTracking().Include(S => S.Department)
                                                                   .Where(S => S.StudentId.Equals(id))
                                                                   .FirstOrDefault();
            return student;
        }

        public async Task<string> AddAsync(Student student)
        {
           

            await _studentRepository.AddAsync(student);

            return "Success";
        
        
        }

        public async Task<bool> IsNameExist(string name)
        {
            var student = _studentRepository.GetTableNoTracking().Where(S => S.NameEn.Equals(name)).FirstOrDefault();
            if (student == null) return false;
            return true;
        }

        public async Task<bool> IsNameExistExecludeSelf(string name, int id)
        {
            var student = await _studentRepository.GetTableNoTracking().Where(S => S.NameEn.Equals(name)&! S.StudentId.Equals(id)).FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
        }

        public async Task<string> EditAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return "Success";
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
           return  await _studentRepository.GetByIdAsync(id);
        }

        public async Task<string> DeleteAsync(Student student)
        {
             await _studentRepository.DeleteAsync(student);
            return "Success";
        }

        public IQueryable<Student> GetStudentsQuerable()
        {
            return _studentRepository.GetTableNoTracking().Include(S => S.Department).AsQueryable();
        }

        public IQueryable<Student> FilterStudentPaginatedQuerabl(SudentOrderingEnum orderingEnum, string search)
        {
           var querable = _studentRepository.GetTableNoTracking().Include(S => S.Department).AsQueryable();
            if (search != null)
            {
                querable = querable.Where(S => S.NameEn.Contains(search) || S.Address.Contains(search));
            }
            switch(orderingEnum)
            {
                case SudentOrderingEnum.StudentId:
                    querable = querable.OrderBy(S => S.StudentId);
                    break;
                case SudentOrderingEnum.Name:
                    querable = querable.OrderBy(S => S.NameEn);
                    break;
                case SudentOrderingEnum.Address:
                    querable = querable.OrderBy(S => S.Address);
                    break;
                default:
                    querable = querable.OrderBy(S => S.Department.DepartmentNameEn);
                    break;
            }    


            return querable;
        }

        public IQueryable<Student> GetStudentsByDepartmentQuerable(int DepartmentId)
        {
            return _studentRepository.GetTableNoTracking().Where(S => S.DepartmentId.Equals(DepartmentId)).AsQueryable();

        }

        #endregion
    }
}
