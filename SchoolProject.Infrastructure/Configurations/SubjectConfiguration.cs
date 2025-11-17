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
    public class SubjectConfiguration : IEntityTypeConfiguration<Subjects>
    {
        public void Configure(EntityTypeBuilder<Subjects> builder)
        {
            builder.HasKey(su => su.SubjectId);
            builder.Property(su => su.SubjectNameEn).HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(su => su.SubjectNameAr).HasColumnType("nvarchar").HasMaxLength(200);
        }
    }
}
