using EM.Planilla.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Infraestructure.Configuration.Repositories.Entities
{
    public class PayrollConfiguration : IEntityTypeConfiguration<Payroll>
    {
        public void Configure(EntityTypeBuilder<Payroll> builder)
        {
            builder.ToTable("payrolls", schema: "planilla");
            builder.HasIndex(p => p.Status);
            builder.OwnsOne(p => p.Period, period => {
                period.Property(a => a.Year)
                .IsRequired()
                .HasMaxLength(4)
                .HasColumnName("year");

                period.Property(a => a.Month)
                .IsRequired()
                .HasMaxLength(2)
                .HasColumnName("month");

                period.HasIndex(d => new { d.Year, d.Month }).IsUnique();
            });
            builder.Property(p => p.Status)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20)
                .HasColumnName("status");
            builder.HasMany(p => p.Payments)
                .WithOne(p => p.Payroll)
                .HasForeignKey(p => p.PayrollId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            builder.Property(p => p.ProcessingDate)
             .IsRequired()
             .HasColumnName("processing_date");
            builder.OwnsOne(p => p.TotalAmount, totalAmount =>
            {
                totalAmount.Property(a => a.Amount)
                .HasColumnName("total_amount")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

                totalAmount.Property(d => d.Currency)
                .IsRequired()
                .HasMaxLength(3)
                .HasColumnName("total_amount_currency");
            });
            builder.Metadata
                .FindNavigation(nameof(Payroll.Payments))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
