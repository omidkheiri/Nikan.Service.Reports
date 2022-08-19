
using MediatR;
using Nikan.Services.Reports.Core.ContactAggregate;

namespace Nikan.Services.Reports.Core.ConttactAggregate.Commands;
public record AddContactCommand(Guid CompanyId, Guid ContactId,
int ContactNumber,
string Name,
string LastName,
string Phone,
string EmailAddress,
DateTimeOffset? BirthDate,
DateTimeOffset DateCreated,
DateTimeOffset DateModified,
Guid CreatedById,
string CreatedBy,
int AccountNumber,
string AccountTitle,
Guid AccountId
  ) : IRequest<Contact>;
