using AutoMapper;
using MediatR;
using Nikan.Services.Reports.Core.AccountAggregate.Commands;
using Nikan.Services.Reports.Infrastructure.Data;

namespace Nikan.Services.Reports.WebApi.Adaptors.AccountAdaptor.Service.Commands
{
  public class SetAccountIsCustomerCommandHandler : IRequestHandler<SetAccountIsCustomerCommand, string>
  {
    private readonly AppDbContext _appDbContext;

    public SetAccountIsCustomerCommandHandler(AppDbContext appDbContext, IMapper mapper) : base()
    {
      _appDbContext = appDbContext;

    }
    async Task<string> IRequestHandler<SetAccountIsCustomerCommand, string>.Handle(SetAccountIsCustomerCommand request, CancellationToken cancellationToken)
    {


      var item = _appDbContext.Accounts.Where(i => i.AccountId == request.AccountId && i.CompanyId == request.CompanyId).FirstOrDefault();
      item.SetIsCustomer(request.IsCustomer);
      _appDbContext.SaveChanges();
      return "OK";


    }
  }
}
