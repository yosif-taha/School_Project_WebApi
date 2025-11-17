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
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(I => I.InstructorId);
            builder.Property(I => I.InstructorNameEn).HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(I => I.InstructorNameAr).HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(I => I.Address).HasColumnType("nvarchar").HasMaxLength(500);


            builder
                .HasOne(S => S.SuperVisor)
                .WithMany(I => I.Instructors)
                .HasForeignKey(S => S.SuperVisorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
