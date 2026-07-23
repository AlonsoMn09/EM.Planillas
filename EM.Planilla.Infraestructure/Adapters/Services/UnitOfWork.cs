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
        private readonly DomainEventDispatcher _dispatcher;
        public UnitOfWork(PlanillaDbContext context, DomainEventDispatcher domainEventDispatcher)
        {
            _context = context;
            _dispatcher = domainEventDispatcher;
        }
        public async Task<int> SaveChangesAsync() 
        {
            await _dispatcher.DispatchEventAsync(_context);
            return await _context.SaveChangesAsync();
        }
    }
}
