using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entity;

namespace Core.EfRepository
{
    public interface ICoreRepository<TEntity> where TEntity : BaseEntity, new()
    {
        /// <summary>
        ///     Return entity according to it's primary key.
        /// </summary>
        /// <param name="id">Entity Id.</param>
        /// <returns>Entity itself.</returns>
        Task<TEntity> GetByIdAsync(int id);

        /// <summary>
        ///     Return first entity according to filter and includes.
        /// </summary>
        /// <param name="filter">Add filters to query.</param>
        /// <param name="includes">Include related tables to query.</param>
        /// <returns>Entity itself.</returns>
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        ///     Return raw query according to filter and includes.
        /// </summary>
        /// <param name="filter">Add filters to query.</param>
        /// <param name="includes">Include related tables to query.</param>
        /// <returns>Raw query</returns>
        IQueryable<TEntity> JustRawQuery(Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        ///     Adds new entity.
        /// </summary>
        /// <param name="entity">Entity.</param>
        Task AddAsync(TEntity entity);

        /// <summary>
        ///     Add new entity list.
        /// </summary>
        /// <param name="entities">Entity list</param>
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        ///     It compares if the entity has any changes and if there is any property change it changes the state of the entity
        ///     and when SaveChanges is used the entity update happens.
        /// </summary>
        /// <param name="entity">Entity itself.</param>
        void Update(TEntity entity);

        /// <summary>
        ///     It compares if the entities has any changes and if there is any property change it changes the state of the
        ///     entities and when SaveChanges is used the entities are updated.
        /// </summary>
        /// <param name="entities">Entity list.</param>
        void UpdateRange(IEnumerable<TEntity> entities);

        /// <summary>
        ///     The Entity is softly deleted.
        /// </summary>
        /// <param name="entity">Entity itself.</param>
        void Delete(TEntity entity);

        /// <summary>
        ///     Entities are softly deleted.
        /// </summary>
        /// <param name="entities">Entity list.</param>
        void DeleteRange(IEnumerable<TEntity> entities);

        /// <summary>
        ///     Returns count of related entities
        /// </summary>
        /// <param name="filter">Add filters to query.</param>
        /// <returns>Count of entities.</returns>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null);

        /// <summary>
        ///     Returns the boolean result based on the desired filter result.
        /// </summary>
        /// <param name="filter">Add filters to query.</param>
        /// <returns>true or false</returns>
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter);
    }
}