// <copyright file="BaseRepository.cs" company="Carguero">
// Copyright (c) Carguero. All rights reserved.
// </copyright>

using System.Linq.Expressions;
using Carguero.Registration.Poc.Domain.Core.Contracts.Repositories;
using Carguero.Registration.Poc.Domain.Core.Entities;
using Carguero.Registration.Poc.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Carguero.Registration.Poc.Infrastructure.Data.Repositories.Base
{
    internal abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
            where TEntity : BaseEntity
    {
        private RegistrationContext _registrationContext;

        private Lazy<DbSet<TEntity>> _dbSet;

        public BaseRepository(RegistrationContext registrationContext)
        {
            _registrationContext = registrationContext;
            _dbSet = new Lazy<DbSet<TEntity>>(() => registrationContext.Set<TEntity>());
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.CreationDate = DateTime.Now;

            var result = await _dbSet.Value.AddAsync(entity);

            return result.Entity;
        }

        public virtual async Task<TEntity?> FindByKeyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var result = await _dbSet.Value.SingleOrDefaultAsync(predicate);

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
            entity.ModificationDate = DateTime.Now;

            _registrationContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task CommitAsync()
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
