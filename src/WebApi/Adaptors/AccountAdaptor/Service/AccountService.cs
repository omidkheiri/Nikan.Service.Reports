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

  public override async Task<AddAccountReply> AddAccount(AddAccountRequest request, ServerCallContext context)
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
      request.CreatedBy);
    var item = await _mediator.Send(command);


    return new AddAccountReply
    {
      Message = "OK"
    };
  }
  public override async Task<SetAccountIsCustomerResponse> SetAccountIsCustomer(SetAccountIsCustomerRequest request, ServerCallContext context)
  {
    var command = new SetAccountIsCustomerCommand(Guid.Parse(request.AccountId), Guid.Parse(request.CompanyId), request.IsCustomer);
    var item = await _mediator.Send(command);


    return new SetAccountIsCustomerResponse
    {
      Message = "OK"
    };
  }
  public override async Task<SetAccountIsSupplierResponse> SetAccountIsSupplier(SetAccountIsSupplierRequest request, ServerCallContext context)
  {
    var command = new SetAccountIsSupplierCommand(Guid.Parse(request.AccountId), Guid.Parse(request.CompanyId), request.IsSupplier);
    var item = await _mediator.Send(command);


    return new SetAccountIsSupplierResponse
    {
      Message = "OK"
    };
  }
}
