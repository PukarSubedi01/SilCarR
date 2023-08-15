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

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual async void Insert(TEntity entity)
        {
            dbSet.Add(entity);
            context.SaveChangesAsync();
        }

        /*public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }*/

        public bool Delete(object id)
        {
            TEntity entityToDelete = context.Set<TEntity>().Find(id);
            if (entityToDelete != null)
            {
                context.Set<TEntity>().Remove(entityToDelete);
                context.SaveChanges();
                return true; // Deletion was successful
            }
            return false; // Deletion failed (entity not found)
        }
        /*public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }*/

        /* public virtual void Update(TEntity entityToUpdate)
         {
             var existingEntity = dbSet.Find(entityToUpdate.id);
             if (existingEntity != null)
             {
                 context.Entry(existingEntity).CurrentValues.SetValues(entityToUpdate);
                 context.SaveChanges();
             }
         }*/

        public virtual void Update(TEntity id)
        {
            dbSet.Attach(id);
            context.Entry(id).State = EntityState.Modified;
            context.SaveChanges();

        }
    }
}
