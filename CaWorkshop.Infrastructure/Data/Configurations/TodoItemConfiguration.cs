using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CaWorkshop.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaWorkshop.Infrastructure.Data.Configurations
{
    public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.Property(e => e.Title)
                .HasMaxLength(280)
                .IsRequired();

            builder.Property(t => t.Note)
                .HasMaxLength(4000);
        }
    }
}
