using ProjectName.Business.Core.Interfaces.Entity;
using ProjectName.Business.Core.Interfaces.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ProjectName.Business.Core.Interfaces.Data
{
    public interface IRepository<T>
        where T : class, IEntity
    {
        IResult<T>             Create(T item, long? createdById = null);
        IResult<List<T>>       Create(IEnumerable<T> items, long? createdById = null);
        IResult<bool>          Delete(long id, long? deletedById = null, bool soft = true);
        IResult<bool>          Delete(T o, long? deletedById = null, bool soft = true);
        IResult<IQueryable<T>> FindAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null);
        IResult<T>             FindById(long id);
        IResult<T>             FindById(long id, params Expression<Func<T, object>>[] includeProperties);
        IResult<T>             FindById(long id, params string[] includeProperties);
        IResult<bool>          Restore(T o);
        IResult<bool>          Restore(long id);
        IResult<bool>          Update(T item, long? updatedBy = null);
    }
}
