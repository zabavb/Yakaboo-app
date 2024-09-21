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
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.Property(item => item.ID).HasColumnName("Id").IsRequired();
            builder.Property(item => item.Name).IsRequired().HasColumnType("varchar").HasMaxLength(50);
        }
    }
}