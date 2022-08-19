using AutoMapper;
using MediatR;
using Nikan.Services.Reports.Core.AccountAggregate.Commands;
using Nikan.Services.Reports.Infrastructure.Data;

namespace Nikan.Services.Reports.WebApi.Adaptors.AccountAdaptor.Service.Commands
{
  public class SetAccountIsSupplieryCommandHandler : IRequestHandler<SetAccountIsSupplierCommand, string>
  {
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;
    public SetAccountIsSupplieryCommandHandler(AppDbContext appDbContext, IMapper mapper) : base()
    {
      _appDbContext = appDbContext;
      _mapper = mapper;
    }
    async Task<string> IRequestHandler<SetAccountIsSupplierCommand, string>.Handle(SetAccountIsSupplierCommand request, CancellationToken cancellationToken)
    {


      var item = _appDbContext.Accounts.Where(i => i.AccountId == request.AccountId && i.CompanyId == request.CompanyId).FirstOrDefault();
      item.SetIsSupplier(request.IsSupplier);
      _appDbContext.SaveChanges();
      return "OK";


    }
  }
}
