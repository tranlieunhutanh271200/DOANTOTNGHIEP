using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Service.Core.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Service.Core.Persistence
{
    public class AsyncRepository<TEntity, TKey> : IAsyncRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        protected readonly IConfiguration _configuration;
        protected readonly DbSet<TEntity> _dbSet;
        public AsyncRepository(DbContext context, IConfiguration configuration)
        {
            _dbContext = context;
            _dbSet = context.Set<TEntity>();
            _configuration = configuration;
        }

        public async Task<TEntity> AddEntity(TEntity entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public async Task<TEntity> DeleteEntity(TKey key)
        {
            var entity = await _dbSet.FindAsync(key);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                return entity;
            }
            return null;
        }

        public Task<TEntity> DeleteEntity(TEntity entity)
        {
            _dbSet.Remove(entity);
            return Task.FromResult(entity);
        }

        public async ValueTask<bool> ExistAsync(params Expression<Func<TEntity, bool>>[] predicates)
        {
            int matchCount = 0;
            foreach (var predicate in predicates)
            {
                if (await _dbSet.AnyAsync(predicate))
                {
                    matchCount++;
                }
            }
            if (matchCount == predicates.Length)
            {
                return true;
            }
            return false;
        }

        public async Task<IReadOnlyCollection<TEntity>> GetAllAsync(bool isTracking = false)
        {
            var entities = _dbSet;
            if (!isTracking)
            {
                return await entities.AsNoTracking().ToListAsync();
            }
            return await entities.ToListAsync();
        }

        public async Task<IReadOnlyCollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, bool isTracking = false)
        {
            var entities = _dbSet.Where(predicate);
            if (!isTracking)
            {
                return await entities.AsNoTracking().ToListAsync();
            }
            return await entities.ToListAsync();
        }

        public async Task<IReadOnlyCollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>> orderBy = null, bool isTracking = false)
        {
            var entities = _dbSet.Where(predicate);
            if (orderBy != null)
            {
                entities = orderBy.Compile().Invoke(entities);
            }
            if (!isTracking)
            {
                return await entities.AsNoTracking().ToListAsync();
            }
            return await entities.ToListAsync();
        }

        public async Task<IReadOnlyCollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>> orderBy, bool isTracking = false, params Expression<Func<TEntity, object>>[] includes)
        {
            var entities = _dbSet.Where(predicate);
            if (orderBy != null)
            {
                entities = orderBy.Compile().Invoke(entities);
            }
            if (!isTracking)
            {
                return await entities.AsNoTracking().ToListAsync();
            }
            if (includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    entities = entities.Include(include);
                }
            }
            return await entities.ToListAsync();
        }

        public async Task<IReadOnlyCollection<TEntity>> GetAllWithIncludesAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includes)
        {
            var entities = _dbSet.AsQueryable();
            if (predicate != null)
            {
                entities = entities.Where(predicate).AsNoTracking();
            }
            if (includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    entities = entities.Include(include);
                }
            }
            return entities.ToList();
        }

        public async Task<TEntity> GetEntity(TKey key)
        {
            return await _dbSet.FindAsync(key);
        }

        public async Task<TEntity> GetEntity(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<TEntity> GetEntity(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var entity = _dbSet.Where(predicate);
            if (includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    entity = entity.Include(include);
                }
            }
            return await entity.FirstOrDefaultAsync();
        }

        public async Task<TEntity> UpdateEntity(TKey key, TEntity entity)
        {
            if (await _dbSet.FindAsync(key) == null)
            {
                return null;
            }
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbSet.Update(entity);
            return entity;
        }

        public async Task<TEntity> UpdateEntity(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
