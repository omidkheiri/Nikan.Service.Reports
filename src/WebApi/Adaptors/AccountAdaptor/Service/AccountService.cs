using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using Nikan.Services.Reports.Core.AccountAggregate.Commands;
using static Nikan.Services.Reports.WebApi.Adaptors.AccountAdaptor.AccountService;

namespace Nikan.Services.Reports.WebApi.Adaptors.AccountAdaptor.Service;

public class GRPCAccountService : AccountServiceBase
{
  private readonly ILogger<GRPCAccountService> _logger;
  private readonly IMediator _mediator;

  public GRPCAccountService(ILogger<GRPCAccountService> logger, IMediator mediator)
  {
    _logger = logger;
    _mediator = mediator;
  }

  public override Task<AddAccountReply> AddAccount(AddAccountRequest request, ServerCallContext context)
  {
    var command = new AddAccountCommand(Guid.Parse(request.CompanyId),
      Guid.Parse(request.AccountId),
      request.AccountNumber,
      request.Title,
      request.Phone,
      request.EmailAddress,
      request.PostalAddress,
      request.DateCreated.ToDateTimeOffset(),
      request.DateModified.ToDateTimeOffset(),
      Guid.Parse(request.CreatedById),
      request.CreatedBy,
      request.IsCustomer,
      request.IsSupplier);
    var item = _mediator.Send(command);


    return Task.FromResult(new AddAccountReply
    {
      Message = "OK"
    });
  }

}
