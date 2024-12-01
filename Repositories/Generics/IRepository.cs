using MovieApp.Data.Generics;

namespace MovieApp.Repositories.Generics
{
    public interface IRepository<TEntity> where TEntity : BaseModel
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> AddAsync(TEntity entity);
        Task AddAsync(List<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
    }
}
