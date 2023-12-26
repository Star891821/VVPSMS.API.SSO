using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VVPSMSV1.API.SSO.Domain.Models;
using VVPSMSV1.API.SSO.Service.Interfaces;

namespace VVPSMSV1.API.SSO.Service.DataManagers
{
    public class GenericService<T> : ICommonService<T> where T : class
    {
        protected VvpsmsSsoContext context;
        internal DbSet<T> dbSet;

        public GenericService(VvpsmsSsoContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<List<T>> GetAll(int id)
        {
            return await dbSet.Where(e => e.Equals(id)).ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> InsertOrUpdateRange(List<T> entity)
        {
            await dbSet.AddRangeAsync(entity);
            return true;
        }
        public virtual async Task<bool> InsertOrUpdate(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> Update(T orginalentity, T entity)
        {
            dbSet.Entry(orginalentity).CurrentValues.SetValues(entity);
            return true;
        }
        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<bool> Remove(T entity)
        {
            dbSet.Remove(entity);
            return true;
        }

        public virtual async Task<bool> RemoveRange(List<T> entity)
        {
            dbSet.RemoveRange(entity);
            return true;
        }
    }
}
