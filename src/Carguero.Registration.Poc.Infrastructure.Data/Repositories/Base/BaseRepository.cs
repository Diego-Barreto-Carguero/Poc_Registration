using Carguero.Registration.Poc.Domain.Core.Contracts.Repositories;
using Carguero.Registration.Poc.Domain.Core.Entities;
using Carguero.Registration.Poc.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Carguero.Registration.Poc.Infrastructure.Data.Repositories.Base
{
    internal abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
            where TEntity : BaseEntity
    {
        private RegistrationContext _registrationContext { get; set; }
        private Lazy<DbSet<TEntity>> _dbSet { get; set; }

        public BaseRepository(RegistrationContext registrationContext)
        {
            _registrationContext = registrationContext;
            _dbSet = new Lazy<DbSet<TEntity>>(() => registrationContext.Set<TEntity>());
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var result = await _dbSet.Value.AddAsync(entity);

            return result.Entity;
        }

        public virtual async Task<TEntity?> FindByKeyAsync(params object[] values)
        {
            var result = await _dbSet.Value.FindAsync(values);

            return result;
        }

        public virtual async Task<IEnumerable<TEntity>> GetByPredicateAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Value.Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetByPredicateAsync(Expression<Func<TEntity, bool>> predicate, int page, int pageSize)
        {
            var query = _dbSet.Value.Where(predicate).AsQueryable();

            var result = await query.Skip(pageSize * (page - 1)).Take(pageSize).ToListAsync();

            return result;
        }

        public virtual void Remove(TEntity entity)
        {
            _dbSet.Value.Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _registrationContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task SaveAsync()
        {
            await _registrationContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetByPredicateAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbSet.Value.Where(predicate).AsQueryable();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            var result = await query.ToListAsync();

            return result;
        }
    }
}
