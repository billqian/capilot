using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Shared.Services;

public interface IRepository<T> where T : BaseEntity
{

    IUnitOfWork UnitOfWork { get; }

    Task<T> InsertAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);

    Task<T> LoadAsync(Guid id);


    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    Task<IEnumerable<T>> FindByPageAsync(Expression<Func<T, bool>> predicate, int page, int pageSize);

}
