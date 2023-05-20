using System.Linq.Expressions;

namespace MovieverseWeb.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        void DeleteAsync(TEntity entity);
        Task<IQueryable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<int> SaveChangesAsync();
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity?> GetByIdAsync(Guid id, params Expression<Func<TEntity, object>>[] includes);
    }
}
