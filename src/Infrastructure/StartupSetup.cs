using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Nikan.Services.Reports.Infrastructure.Data;
using Nikan.Services.Reports.Infrastructure.Options;

namespace Nikan.Services.Reports.Infrastructure;

public static class StartupSetup
{
  public static IConfiguration Configuration { get; set; }
  public static void AddDbContext(this IServiceCollection services, string connectionString)
  {
    services.AddDbContext<AppDbContext>(options =>
      options.UseNpgsql(connectionString));
    // will be created in web project root

  }
  public static void ConfigureServices(IServiceCollection services)
  {
    var basicDataServiceConfiguration = Configuration.GetSection(nameof(BasicDataService)).Get<BasicDataService>();
    services.AddSingleton(basicDataServiceConfiguration);

  }




}
