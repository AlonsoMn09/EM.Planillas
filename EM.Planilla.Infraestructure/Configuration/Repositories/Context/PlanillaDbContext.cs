using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using EM.Planilla.Domain.Entities;

namespace EM.Planilla.Infraestructure.Configuration.Repositories.Context
{
    //public class PlanillaDbContext(DbContextOptions<PlanillaDbContext> options) : DbContext(options)
    public class PlanillaDbContext(DbContextOptions<PlanillaDbContext> options) : DbContext(options)
    {
        //public PlanillaDbContext()
        //{
                
        //}
        //public PlanillaDbContext(DbContextOptions<PlanillaDbContext> options) : base(options)
        //{
            
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=localhost;Port=1502;Database=db_planilla;Username=admin;Password=Password2026");
        //}

        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("planilla");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlanillaDbContext).Assembly);
        }
    }
}
