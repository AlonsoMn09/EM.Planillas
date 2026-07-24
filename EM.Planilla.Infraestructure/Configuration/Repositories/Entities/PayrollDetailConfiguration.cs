using EM.Planilla.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Infraestructure.Configuration.Repositories.Entities
{
    public class PayrollDetailConfiguration : IEntityTypeConfiguration<PayrollDetail>
    {
        public void Configure(EntityTypeBuilder<PayrollDetail> builder)
        {
            builder.ToTable("payroll_details", schema: "planilla");
            builder.HasIndex(p => p.PayrollId);
            builder.HasIndex(p => p.EmployeeId);
            builder.Property(p => p.EmployeeFullName)
               .HasColumnName("employee_name")
               .IsRequired()
               .HasMaxLength(200);

            builder.Property(p => p.TotalEarnings)
              .HasColumnName("total_earnings")
              .IsRequired()
              .HasColumnType("decimal(18,2)");
            builder.Property(p => p.TotalDeductions)
              .HasColumnName("afp")
              .IsRequired()
              .HasColumnType("decimal(18,2)");
            builder.Property(p => p.TotalDeductions)
              .HasColumnName("total_deductions")
              .IsRequired()
              .HasColumnType("decimal(18,2)");
            builder.Property(p => p.TotalDeductions)
              .HasColumnName("total_deductions")
              .IsRequired()
              .HasColumnType("decimal(18,2)");
            builder.Property(p => p.TotalDeductions)
              .HasColumnName("net_pay")
              .IsRequired()
              .HasColumnType("decimal(18,2)");           
            builder.HasOne(p => p.Payroll)
                .WithMany(c => c.Payments)
                .HasForeignKey(p => p.PayrollId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
