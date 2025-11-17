using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(S => S.StudentId);
            builder.Property(S => S.NameEn).HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(S => S.NameAr).HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(S => S.Address).HasColumnType("nvarchar").HasMaxLength(500);

        }
    }
}
