using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SilverCarRental.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal SilverDataContext context;
        internal DbSet<TEntity> dbSet;

        public Repository(SilverDataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }   

        public async virtual Task<IEnumerable<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
                           
            query = QueryAfterInclude(query, includeProperties);
            

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }


        /* public async virtual Task<TEntity> GetByID(object id,
              string includeProperties = "") 
         {
             ParameterExpression parameter = Expression.Parameter(typeof(TEntity), "x");
             Expression idProperty = Expression.Property(parameter, "Id"); 

             ConstantExpression idValue = Expression.Constant(id);

             BinaryExpression equalExpression = Expression.Equal(idProperty, idValue);

             Expression<Func<TEntity, bool>> filterExpression = Expression.Lambda<Func<TEntity, bool>>(equalExpression, parameter);
             IQueryable<TEntity> query = dbSet;
             query = QueryAfterInclude(query, includeProperties);
             return await query.FirstOrDefaultAsync(filterExpression);
         }*/
        public async Task<TEntity> GetByID(Expression<Func<TEntity, bool>> idFilter, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
            query = QueryAfterInclude(query, includeProperties);
            return await query.FirstOrDefaultAsync(idFilter);
        }
        public async virtual Task<TEntity> Insert(TEntity entity)
        {
            dbSet.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async virtual Task<TEntity> Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            await Delete(entityToDelete);
            return entityToDelete;
        }

        public async virtual Task<TEntity> Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            await context.SaveChangesAsync();
            return entityToDelete;
        }

        public async virtual Task<TEntity> Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entityToUpdate;
        }

        private IQueryable<TEntity> QueryAfterInclude(IQueryable<TEntity> query, string includeProperties = "")
        {
            foreach (var includeProperty in includeProperties.Split
               (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

       
    }
}
