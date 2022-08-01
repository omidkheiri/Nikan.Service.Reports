using AutoMapper;
using MediatR;
using Nikan.Services.Reports.Core.AccountAggregate;
using Nikan.Services.Reports.Core.AccountAggregate.Commands;
using Nikan.Services.Reports.Infrastructure.Data;

namespace Nikan.Services.Reports.WebApi.Adaptors.AccountAdaptor.Service.Commands;

public class AddAccountCommandHandler : IRequestHandler<AddAccountCommand, Account>
{
  private readonly AppDbContext _appDbContext;
  private readonly IMapper _mapper;
  public AddAccountCommandHandler(AppDbContext appDbContext, IMapper mapper) : base()
  {
    _appDbContext = appDbContext;
    _mapper = mapper;
  }
  async Task<Account> IRequestHandler<AddAccountCommand, Account>.Handle(AddAccountCommand request, CancellationToken cancellationToken)
  {
    var account = _mapper.Map<Account>(request);
    try
    {
      _appDbContext.Accounts.Add(account);
      _appDbContext.SaveChanges();
      return account;
    }
    catch (Exception ex)
    {
      var message = ex.Message;

      throw;
    }

  }
}
