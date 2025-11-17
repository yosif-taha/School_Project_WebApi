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
    public class DepartmentSubjectConfiguration : IEntityTypeConfiguration<DepartmetSubject>
    {
        public void Configure(EntityTypeBuilder<DepartmetSubject> builder)
        {
            builder
                 .HasKey(DS => new { DS.DepartmentId, DS.SubjectId });
          
            builder.HasOne(DS => DS.Department)
                .WithMany(D => D.DepartmentSubjects)
                .HasForeignKey(DS => DS.DepartmentId);
            
            builder.HasOne(DS => DS.Subject)
                .WithMany(S => S.DepartmetsSubjects)
                .HasForeignKey(DS => DS.SubjectId);
        }
    }
}
