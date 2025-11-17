using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Configurations
{
    public class StudentSubjectConfiguration : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            builder
                 .HasKey(SS => new { SS.StudentId, SS.SubjectId });
         
            builder.HasOne(SS => SS.Student)
                .WithMany(S => S.StudentSubject)
                .HasForeignKey(SS => SS.SubjectId);

            builder.HasOne(SS => SS.Subject)
                .WithMany(su => su.StudentsSubjects)
                .HasForeignKey(SS => SS.SubjectId);
        }
    }
}
