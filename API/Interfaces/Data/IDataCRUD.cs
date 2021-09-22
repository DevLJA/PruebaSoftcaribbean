using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Data
{
    public interface IDataCRUD<TEntity>
    {
        Task<TEntity> Insert(TEntity entityInsert);
        Task Delete(TEntity entityDelete);
        Task<TEntity> GetByWhere(Expression<Func<TEntity, bool>> where);
        Task Update(TEntity entityUpdate);
        Task<List<TEntity>> GetListIncludeProperties(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] propertyNames);
        Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> where);
        Task<List<TEntity>> GetList();
    }
}
