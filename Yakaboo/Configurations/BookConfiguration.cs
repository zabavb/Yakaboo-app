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
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(item => item.ID).HasColumnName("Id").IsRequired();
            builder.Property(item => item.Title).IsRequired().HasColumnType("varchar").HasMaxLength(80);
            builder.Property(item => item.Size).HasColumnName("Pages").IsRequired();
            builder.Property(item => item.AuthorID).HasColumnName("AuthorId");
            builder.Property(item => item.PublisherID).HasColumnName("PublisherId");
        }
    }
}