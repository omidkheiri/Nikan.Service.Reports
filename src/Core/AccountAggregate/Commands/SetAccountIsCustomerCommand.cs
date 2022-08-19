
using MediatR;

namespace Nikan.Services.Reports.Core.AccountAggregate.Commands;

public record SetAccountIsCustomerCommand(Guid AccountId, Guid CompanyId, bool IsCustomer) : IRequest<string>;
