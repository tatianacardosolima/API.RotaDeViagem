using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RotaDeViagem.Shared.Interfaces.IEntities;

namespace RotaDeViagem.Shared.Interfaces.IRepositories
{
    public interface IRepository<T, in TId>
             where T : IEntity
             where TId : struct
    {        
        #region Insert
        Task InsertAsync(T entity);
        Task InsertRangeAsync(List<T> entities);
        #endregion

        #region Update
        void Update(T entity);
        void UpdateRange(List<T> entities);
        #endregion

        #region Delete
        void LogicalDelete(T obj);
        void Delete(T entity);
        #endregion

        #region Get
        Task<T> GetByIdAsync(TId id);
        Task<T> GetByUniqueIdAsync(Guid uniqueId);
        Task<List<T>> GetAllAsync();
        #endregion

        #region Pagination
        Task<List<T>> PaginationAsync(Expression<Func<T, bool>> expression, int skip, int take);
        #endregion

        #region Find
        Task<List<T>> FindAsync(Expression<Func<T, bool>> expression);
        #endregion

        #region Exists
        Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);
        #endregion

        #region SaveChanges
        void SaveChanges();
        Task SaveChangesAsync();
        #endregion
    }
}
