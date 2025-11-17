using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Repositories
{
    public class SubjectRepository : GenericRepositoryAsync<Subjects> , ISubjectRepository
    {
        #region Fields

        #endregion
        #region Constructors

        public SubjectRepository(ApplicationDbContext context) : base(context)
        {

        }
        #endregion
        #region Functions

        #endregion
    }
}
