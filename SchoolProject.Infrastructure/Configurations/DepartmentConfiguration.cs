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
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(D => D.DepartmentId);
            builder.Property(D => D.DepartmentNameEn).HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(D => D.DepartmentNameAr).HasColumnType("nvarchar").HasMaxLength(200);

            builder
              .HasOne(I => I.Instructor)
              .WithOne(D => D.DepartmentManager)
              .HasForeignKey<Department>(D => D.InsructorId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(D => D.Instructors)
                   .WithOne(I => I.Department)
                   .HasForeignKey(I => I.DepartmentId);

            builder.HasMany(D => D.Students)
                   .WithOne(S => S.Department)
                   .HasForeignKey(S => S.DepartmentId);

            
        }
    }
}
