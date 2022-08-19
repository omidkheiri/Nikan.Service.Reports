using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;


namespace Nikan.Services.Reports.WebApi.V1.Endpoints.ContactEndPoints;

public class ListAccountRequest
{
  [FromRoute(Name = "companyid")] public Guid CompanyId { get; set; }
  [FromQuery] public Guid? AccountId { get; set; }
  [FromQuery] public DataSourceLoadOptions? LoadOptions { get; set; }


}
