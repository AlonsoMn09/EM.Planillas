using EM.Planilla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EM.Planilla.Domain.Ports.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<(ICollection<TResult> Result, int TotalRows)> ListAsync<TResult>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TResult>> selector,
            int pageNumber = 1, int pageSize = 10);
        Task<ICollection<TEntity?>> FindAsyncAll(Expression<Func<TEntity, bool>> predicate);
        Task<ICollection<TEntity>> ListAsyncQuery(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
    }
}
