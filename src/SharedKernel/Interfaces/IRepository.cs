using System.Linq.Expressions;
using Ardalis.Specification;

namespace Nikan.Services.Reports.SharedKernel.Interfaces;

// from Ardalis.Specification
public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
  IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

}

