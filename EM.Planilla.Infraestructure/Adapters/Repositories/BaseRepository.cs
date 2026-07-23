using EM.Planilla.Domain.Entities;
using EM.Planilla.Domain.Ports.Repositories;
using EM.Planilla.Infraestructure.Configuration.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EM.Planilla.Infraestructure.Adapters.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly PlanillaDbContext _context;
        public BaseRepository(PlanillaDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var response = await _context.Set<TEntity>().AddAsync(entity);
            return response.Entity;
        }

        public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>()
               .Where(predicate)
               .AsNoTracking()
               .FirstOrDefaultAsync();
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<(ICollection<TResult> Result, int TotalRows)> ListAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector, int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.Set<TEntity>()
                .Where(predicate);

            var result = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .Select(selector)
                .ToListAsync();

            var totalRows = await query.CountAsync();
            return (result, totalRows);
        }
    }
}
