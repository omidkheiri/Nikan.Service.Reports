
using MediatR;

namespace Nikan.Services.Reports.Core.AccountAggregate.Commands;
public record AddAccountCommand(Guid CompanyId,
 Guid AccountId,
 int AccountNumber,
 string Title,
 string Phone,
 string EmailAddress,
 string? PostalAddress,
 DateTimeOffset DateCreated,
 DateTimeOffset DateModified,
 Guid CreatedById,
 string CreatedBy,
 bool IsCustomer,
 bool IsSupplier) : IRequest<Account>;
