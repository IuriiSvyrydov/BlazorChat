using System.Linq.Expressions;
using BlazorChat.Api.Domain.Models;

namespace BlazorChat.Api.Application.Interfaces.Repositories;

public interface IGenericRepository<TEntity>where TEntity: BaseEntity
{
    #region Add Operation

    Task<int> AddAsync(TEntity entity);
    int Add(TEntity entity);
    Task<int> Add(IEnumerable<TEntity> entities);

    #endregion

    #region Update Operation

    Task<int> UpdateAsync(TEntity entity);

    #endregion
    #region Delete Operation

    Task<int> DeleteAsync(TEntity entity);
    int Delete(TEntity entity);
    Task<int>DeleteAsync(Guid id);
    bool DeleteRange(Expression <Func<TEntity, bool>> predicate);
    Task<bool>DeleteRangeAsync(Expression<Func<TEntity, bool>> predicate);
    #endregion

    Task<int> AddOrUpdateAsync(TEntity entity);
    int AddOrUpdate(TEntity entity);
    IQueryable<TEntity> AsQueryable();
    Task<List<TEntity>> GetAll(bool noTracking = true);

    Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> predicate, bool noTracking = true,
        Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>>orderBy = null , params Expression<Func<TEntity,
            object>>[]includes);

    Task<TEntity> GetByIdAsync(Guid id, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);

    Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = true,
        params Expression<Func<TEntity, object>>[] includes);

    Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = true,
        params Expression<Func<TEntity, object>>[]includes);

    IQueryable<TEntity> Get(Expression<Func<TEntity,bool>>predicate, bool noTracking = true,
        params Expression<Func<TEntity, object>>[]includes);

    Task BulkDeleteBuIdAsync(IEnumerable<Guid> ids);
    Task BulkDelete(IEnumerable<TEntity> entities);
    Task BulkDelete(Expression<Func<TEntity, bool>> predicate);
    Task BulkUpdate(IEnumerable<TEntity> entities);
    Task BulkAdd(IEnumerable<TEntity> entities);

}