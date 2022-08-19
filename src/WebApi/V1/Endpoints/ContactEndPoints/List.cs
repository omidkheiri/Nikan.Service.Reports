using Ardalis.ApiEndpoints;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Nikan.Services.Reports.Infrastructure.Data;
using Swashbuckle.AspNetCore.Annotations;

namespace Nikan.Services.Reports.WebApi.V1.Endpoints.ContactEndPoints;


[Route("/V1/Company/")]
public class List : EndpointBaseAsync.WithRequest<ListAccountRequest>.WithResult<object>
{
  private readonly AppDbContext _context;

  public List(AppDbContext context)
  {
    _context = context;

  }
  [HttpGet("{companyid}/Contacts")]
  [SwaggerOperation(Summary = "List Contact", Description = "List Contact record",
    OperationId = "Contacts.List"
    , Tags = new[] { "ContactEndPoint" })]
  public override async Task<object> HandleAsync([FromRoute] ListAccountRequest request, CancellationToken cancellationToken = new CancellationToken())
  {
    var query = _context.Conatcts.Where(i => i.CompanyId == request.CompanyId);
    if (request.AccountId != null && request.AccountId != Guid.Empty)
    {
      query=query.Where(i => i.AccountId == request.AccountId);
    }
    return await Task.FromResult(DataSourceLoader.Load(query, request.LoadOptions));


  }
}
