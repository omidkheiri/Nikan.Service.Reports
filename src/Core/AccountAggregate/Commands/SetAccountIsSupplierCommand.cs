
using MediatR;

namespace Nikan.Services.Reports.Core.AccountAggregate.Commands;

public record SetAccountIsSupplierCommand(Guid AccountId, Guid CompanyId, bool IsSupplier) : IRequest<string>;
