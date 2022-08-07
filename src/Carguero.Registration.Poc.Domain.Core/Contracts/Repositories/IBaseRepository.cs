using Carguero.Registration.Poc.Domain.Core.Entities;
using System.Linq.Expressions;

namespace Carguero.Registration.Poc.Domain.Core.Contracts.Repositories
{
    public interface IBaseRepository<TEntity>
         where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        Task<TEntity?> FindByKeyAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetByPredicateAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetByPredicateAsync(Expression<Func<TEntity, bool>> predicate, int page, int pageSize);
        Task<IEnumerable<TEntity>> GetByPredicateAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        Task CommitAsync();
    }
}
