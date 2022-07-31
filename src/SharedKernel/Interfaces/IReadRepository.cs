using Ardalis.Specification;

namespace Nikan.Services.Reports.SharedKernel.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
