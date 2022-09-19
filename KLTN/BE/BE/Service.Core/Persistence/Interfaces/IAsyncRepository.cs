using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Service.Core.Persistence.Interfaces
{
    public interface IAsyncRepository<TEntity, TKey> where TEntity : class
    {
        Task<IReadOnlyCollection<TEntity>> GetAllWithIncludesAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includes);
        Task<IReadOnlyCollection<TEntity>> GetAllAsync(bool isTracking = false);
        Task<IReadOnlyCollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, bool isTracking = false);
        Task<IReadOnlyCollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>> orderBy, bool isTracking = false);
        Task<IReadOnlyCollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>> orderBy, bool isTracking = false, params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetEntity(TKey key);
        ValueTask<bool> ExistAsync(params Expression<Func<TEntity, bool>>[] predicates);
        Task<TEntity> GetEntity(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetEntity(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> AddEntity(TEntity entity);

        Task<TEntity> UpdateEntity(TKey key, TEntity entity);
        Task<TEntity> UpdateEntity(TEntity entity);

        Task<TEntity> DeleteEntity(TKey key);
        Task<TEntity> DeleteEntity(TEntity entity);
    }
}
