using Interfaces.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation.Generic
{
    public class DataGenericCRUD<TEntity> : BaseData, IDataCRUD<TEntity> where TEntity : class
    {
        public async Task Delete(TEntity entityDelete)
        {
            using (var context = GetContext())
            {
                context.Set<TEntity>().Remove(entityDelete);
                await context.SaveChangesAsync();
            }
        }

        public async Task<TEntity> GetByWhere(Expression<Func<TEntity, bool>> where)
        {
            using (var context = GetContext())
                return await context.Set<TEntity>().FirstOrDefaultAsync(where);
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> where)
        {
            using (var context = GetContext())
                return await context.Set<TEntity>().Where(where).ToListAsync();
        }

        public async Task<List<TEntity>> GetList()
        {
            using (var context = GetContext())
                return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetListIncludeProperties(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] propertyNames)
        {
            using (var context = GetContext())
            {
                var query = context.Set<TEntity>().Where(where);
                foreach (var item in propertyNames)
                    query = query.Include(item);
                
                return await query.ToListAsync();
            }
        }

        public async Task Insert(TEntity entityInsert)
        {
            using (var context = GetContext())
            {
                context.Set<TEntity>().Add(entityInsert);
                await context.SaveChangesAsync();
            }
        }

        public async Task Update(TEntity entityUpdate)
        {
            using (var context = GetContext())
            {
                context.Set<TEntity>().Update(entityUpdate);
                await context.SaveChangesAsync();
            }
        }
    }
}
