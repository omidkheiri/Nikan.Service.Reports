using Ardalis.ApiEndpoints;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Nikan.Services.Reports.Infrastructure.Data;
using Swashbuckle.AspNetCore.Annotations;

namespace Nikan.Services.Reports.WebApi.V1.Endpoints.AccountEndPoints;


[Route("/V1/Company/")]
public class List : EndpointBaseAsync.WithRequest<ListAccountRequest>.WithResult<object>
{
  private readonly AppDbContext _context;

  public List(AppDbContext context)
  {
    _context = context;

  }
  [HttpGet("{companyid}/Account")]
  [SwaggerOperation(Summary = "List Account", Description = "List Account record",
    OperationId = "Accountes.List"
    , Tags = new[] { "AccountesEndPoint" })]
  public override async Task<object> HandleAsync([FromRoute] ListAccountRequest request, CancellationToken cancellationToken = new CancellationToken())
  {

    return await Task.FromResult(DataSourceLoader.Load(_context.Accounts.Where(i => i.CompanyId == request.CompanyId), request.LoadOptions));


  }
}
