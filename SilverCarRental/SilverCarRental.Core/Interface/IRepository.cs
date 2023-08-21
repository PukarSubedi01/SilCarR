using System.Linq.Expressions;

namespace SilverCarRental.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Delete(object id);
        Task<TEntity> Delete(TEntity entityToDelete);
       Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        Task<TEntity> GetByID(Expression<Func<TEntity, bool>> idFilter = null, string includeProperties = "");
        //Task<TEntity> GetByID(object id, string includeProperties = "");
        Task<TEntity> Insert(TEntity entity);
        Task<TEntity> Update(TEntity entityToUpdate);
    }
}