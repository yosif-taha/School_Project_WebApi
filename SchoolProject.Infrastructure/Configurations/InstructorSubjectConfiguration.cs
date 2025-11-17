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
    public class InstructorSubjectConfiguration : IEntityTypeConfiguration<InstructorSubject>
    {
        public void Configure(EntityTypeBuilder<InstructorSubject> builder)
        {
            builder
                .HasKey(IS => new { IS.InstructorId, IS.SubjectId });

            builder.HasOne(IS => IS.Subjects)
                   .WithMany(S => S.InstructorsSubjects)
                   .HasForeignKey(IS => IS.SubjectId);
          
            builder.HasOne(IS => IS.Instructor)
                   .WithMany(S => S.InstructorsSubjects)
                   .HasForeignKey(IS => IS.InstructorId);
        }
    }
}
