using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Core.EfRepository
{
    public class CoreRepository<TEntity> : ICoreRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly DbSet<TEntity> _dbSet;

        protected CoreRepository(DbContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            var baseEntities = _dbSet.Where(filter!);
            if (!includes.Any()) return await _dbSet.FirstOrDefaultAsync();
            foreach (var include in includes) baseEntities.Include(include);

            return await baseEntities.FirstOrDefaultAsync();
        }

        public IQueryable<TEntity> JustRawQuery(Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;
            query = query.Where(filter!);
            if (!includes.Any()) return query;
            foreach (var include in includes) query.Include(include);

            return query;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AttachRange(entities);
        }

        public void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            var baseEntities = entities as TEntity[] ?? entities.ToArray();
            foreach (var entity in baseEntities) entity.IsDeleted = true;

            UpdateRange(baseEntities);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _dbSet.Where(filter!).CountAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet.Where(filter!).AnyAsync();
        }
    }
}