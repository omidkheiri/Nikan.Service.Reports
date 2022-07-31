using System.Linq.Expressions;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nikan.Services.Reports.Core.AccountAggregate;
using Nikan.Services.Reports.SharedKernel.Interfaces;

namespace Nikan.Services.Reports.Infrastructure.Data;

// inherit from Ardalis.Specification type
public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>,
  IRepository<T> where T : class, IAggregateRoot
{
  private readonly AppDbContext _appDbContext;
  public EfRepository(AppDbContext appDbContext) : base(appDbContext)
  {
    _appDbContext = appDbContext;

  }


  public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
  {
    return _appDbContext.Set<T>()
      .Where(expression)
      .AsNoTracking();
  }
}
