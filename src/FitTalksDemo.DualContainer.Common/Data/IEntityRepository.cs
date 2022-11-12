using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using FitTalksDemo.DualContainer.Common.Entities;

namespace FitTalksDemo.DualContainer.Common.Data
{
    public interface IEntityRepository<TEntity> where TEntity : class, IEntity, new() //ADO.NET Efcore or etc
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate,
            bool disableTracking = true,
            params Expression<Func<TEntity, object>>[] includeProperties
            );
        Task<IReadOnlyList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null,
            bool disableTracking = true,
            params Expression<Func<TEntity, object>>[] includeProperties);
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByIdAsync(int id);
    }
}
