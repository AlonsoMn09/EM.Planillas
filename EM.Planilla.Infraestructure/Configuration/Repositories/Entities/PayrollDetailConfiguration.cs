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
            builder.HasOne(p => p.Payroll)
                .WithMany(c => c.Payments)
                .HasForeignKey(p => p.PayrollId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
