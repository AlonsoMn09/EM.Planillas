using EM.Planilla.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Infraestructure.Configuration.Repositories.Entities
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.ToTable("loans", schema: "planilla");

            builder.HasIndex(p => p.Status);
            builder.HasIndex(p => p.EmployeeId);
            builder.OwnsOne(p => p.Amount, amount =>
            {
                amount.Property(a => a.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)")
                .HasColumnName("amount");

                amount.Property(a => a.Currency)
                .IsRequired()
                .HasMaxLength(3)
                .HasColumnName("amount_currency");
            });
            builder.OwnsOne(p => p.Term, term => {
                term.Property(a => a.Months)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("term_months");
            });
            builder.Property(p => p.ReasonStatus)
                .IsRequired(false)
                .HasMaxLength(200)
                .HasColumnName("reason_status");
            builder.HasOne(p => p.Employee)
                .WithMany(c => c.Loans)
                .HasForeignKey(p => p.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();            
        }
    }
}
