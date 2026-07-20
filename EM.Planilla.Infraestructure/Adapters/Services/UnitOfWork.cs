using EM.Planilla.Domain.Ports.Services;
using EM.Planilla.Infraestructure.Configuration.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Infraestructure.Adapters.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PlanillaDbContext _context;        
        public UnitOfWork(PlanillaDbContext context)
        {
            _context = context;
        }
        public async Task<int> SaveChangesAsync() 
        {
            return await _context.SaveChangesAsync();
        }
    }
}
