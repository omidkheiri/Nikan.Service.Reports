using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using Nikan.Services.Reports.Core.ConttactAggregate.Commands;
using static Nikan.Services.Reports.WebApi.Adaptors.ContactAdaptor.ContactService;

namespace Nikan.Services.Reports.WebApi.Adaptors.ContactAdaptor.Service;

public class GRPCContactService : ContactServiceBase
{
  private readonly ILogger<GRPCContactService> _logger;
  private readonly IMediator _mediator;

  public GRPCContactService(ILogger<GRPCContactService> logger, IMediator mediator)
  {
    _logger = logger;
    _mediator = mediator;
  }

  public override async Task<AddContactReply> AddContact(AddContactRequest request, ServerCallContext context)
  {

    var command = new AddContactCommand(Guid.Parse(request.CompanyId),
      Guid.Parse(request.ContactId),
request.ContactNumber,
request.Name,
request.LastName,
request.Phone,
request.EmailAddress,
request.BirthDate.ToDateTimeOffset(),
request.DateCreated.ToDateTimeOffset(),
request.DateModified.ToDateTimeOffset(),
Guid.Parse(request.CreatedById),
request.CreatedBy,
request.AccountNumber,
request.AccountTitle,
Guid.Parse(request.AccountId));
    try
    {
      await _mediator.Send(command);
    }
    catch (Exception ex)
    {
      var a = ex;
    }

    return new AddContactReply
    {
      Message = "OK"
    };
  }
}
