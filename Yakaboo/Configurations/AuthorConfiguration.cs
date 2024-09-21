using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yakaboo.Models;

namespace Yakaboo.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(item => item.ID).HasColumnName("Id").IsRequired();
            builder.Property(item => item.Name).HasColumnName("FirstName").IsRequired().HasColumnType("varchar").HasMaxLength(20);
            builder.Property(item => item.Surname).HasColumnName("LastName").IsRequired().HasColumnType("varchar").HasMaxLength(40);
        }
    }
}