using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EM.Planilla.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EM.Planilla.Infraestructure.Configuration.Repositories.Entities
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("employee", schema: "planilla");
            
            builder.Property(c => c.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.LastName)
                .HasColumnName("last_name")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(200);

            builder.OwnsOne(p => p.Document, document =>
            {
                document.Property(d => d.Number)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("document_number");

                document.Property(d => d.Type)
                .IsRequired()
                .HasMaxLength(3)
                .HasColumnName("document_type");

                document.HasIndex(d => new { d.Type, d.Number }).IsUnique();
            });

            builder.Property(p => p.Status)
              .IsRequired()
              .HasConversion<string>()
              .HasMaxLength(20)
              .HasColumnName("status");
        }
    }
}
